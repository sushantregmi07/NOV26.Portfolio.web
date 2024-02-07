namespace NOV26.Portfolio.web.Models;

public class HomeViewModel:PersonalInformationModel
{
    public List<ResumeModel> Resumes { get; set; }
    public List<ServiceModel> Services { get; set; }
    
}