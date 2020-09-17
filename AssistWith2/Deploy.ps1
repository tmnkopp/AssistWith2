## UPDATE AspNetCoreModuleV2
$releaseto = "C:\inetpub\wwwroot\prod\AssistWith2\" 
$webconf = $releaseto + "web.config" 
$content = Get-Content -Path $webconf 
$content = $content.Replace("AspNetCoreModule""","AspNetCoreModuleV2""")
Set-Content -Path $webconf -Value $content  
