using AssistWith.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssistWith.Data;
namespace AssistWith.Services
{
    public interface IProfileService
    {
        void Delete(Profile Profile);
        IQueryable<Profile> GetAll();
        Profile GetById(int ProfileId);
        void Insert(Profile Profile);
        void Update(Profile Profile);
    }
    public class ProfileService : IProfileService
    {
        private readonly IRepository<Profile> _repository;
        private readonly IEncryptionService _encryptionService;
        public ProfileService()
        {
        }
        public ProfileService(
            IRepository<Profile> ProfileRepository
            , IEncryptionService EncryptionService )
        {
            this._repository = ProfileRepository;
            this._encryptionService = EncryptionService;
        }

        public virtual Profile GetById(int id)
        {
            Profile instance = _repository.GetById(id);
            if (instance.Password != null)
                instance.Password = _encryptionService.Decrypt(instance.Password, instance.PasswordSalt);
            return instance;
        }
        public virtual IQueryable<Profile> GetAll()
        {
            IQueryable<Profile> instances = _repository.Table;
            foreach (var instance in instances)
            {
                if (instance.Password != null) { 
                    instance.Password = _encryptionService.Decrypt(instance.Password, instance.PasswordSalt);
                }
            }
            return instances;
        }
        public virtual void Insert(Profile instance)
        {
            if (instance == null)
                throw new ArgumentNullException(this.ToString());

            instance.PasswordSalt = _encryptionService.CreateSalt(24);
            instance.Password = _encryptionService.Encrypt(instance.Password, instance.PasswordSalt); 
            _repository.Insert(instance);
        }
        public virtual void Update(Profile instance)
        {
            if (instance == null)
                throw new ArgumentNullException(this.ToString());

            instance.PasswordSalt = DbUtil.GetSaltById(instance.ProfileId);
            instance.Password = _encryptionService.Encrypt(instance.Password, instance.PasswordSalt);

            _repository.Update(instance);
        }
        public virtual void Delete(Profile instance)
        {
            if (instance == null)
                throw new ArgumentNullException(this.ToString());
            _repository.Delete(instance);
        }
        
    }
}