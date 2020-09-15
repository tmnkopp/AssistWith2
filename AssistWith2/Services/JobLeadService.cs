using AssistWith.Data;
using AssistWith.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AssistWith.Services
{
    public interface IJobLeadService
    {
        void Delete(JobLead jobLead);
        IQueryable<JobLead> GetAll();
        JobLead GetById(int id);
        void Insert(JobLead jobLead);
        void Update(JobLead jobLead);
        string CompileTemplate(string Content, JobLead jobLead); 
    }
    public class JobLeadService : IJobLeadService
    {
        private readonly IRepository<JobLead> _repository;
        private readonly IEncryptionService _encryptionService;
        public JobLeadService()
        {
        }
        public JobLeadService(IRepository<JobLead> jobLeadRepository
             , IEncryptionService EncryptionService)
        {
            this._repository = jobLeadRepository;
            this._encryptionService = EncryptionService;
        }
        public virtual JobLead GetById(int id)
        {
            JobLead instance = _repository.GetById(id);
            if (instance.Password != null)
                instance.Password = _encryptionService.Decrypt(instance.Password, instance.PasswordSalt); 
            return instance;
        }
        public virtual IQueryable<JobLead> GetAll()
        {
            IQueryable<JobLead> instances = _repository.Table;
            foreach (var instance in instances)
            {
                if (instance.Password != null) 
                    instance.Password = _encryptionService.Decrypt(instance.Password, instance.PasswordSalt); 
            }
            return instances;
        }
        public virtual void Insert(JobLead instance)
        {
            if (instance == null)
                throw new ArgumentNullException(this.ToString()); 
            instance.PasswordSalt = _encryptionService.CreateSalt(24);
            instance.Password = _encryptionService.Encrypt(instance.Password, instance.PasswordSalt);
            _repository.Insert(instance);
        }
        public virtual void Update(JobLead instance)
        {
            if (instance == null)
                throw new ArgumentNullException(this.ToString()); 
            instance.PasswordSalt = DbUtil.GetSaltById(instance.JobLeadId);
            instance.Password = _encryptionService.Encrypt(instance.Password, instance.PasswordSalt); 
            _repository.Update(instance);
        }
        public virtual void Delete(JobLead instance)
        {
            if (instance == null)
                throw new ArgumentNullException(this.ToString());
            _repository.Delete(instance);
        }
        public virtual string CompileTemplate(string TemplateContent, JobLead item) {
            var props = typeof(JobLead).GetProperties();
            foreach (var prop in props)
            {
                string val = prop.GetValue(item) == null ? "" : prop.GetValue(item).ToString();
                TemplateContent = TemplateContent.Replace(
                        string.Format("#{0}#",prop.Name.ToString()), val
                    );
            }
            return TemplateContent; 
        }
    }
}