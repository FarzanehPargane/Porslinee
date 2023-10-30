using HSoft.Porsline.Business.Definitions;
using HSoft.Porsline.Business.Definitions.Dtos;
using HSoft.Porsline.Business.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSoft.Porsline.Controllers
{
    [ApiController]
    [Route("api/Questionnaire")]
    
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService questionnaireService;
        public QuestionnaireController(IQuestionnaireService questionnaireService)
        {
            this.questionnaireService = questionnaireService;
        }

        [HttpGet]
        [Route("PatientQuestionnaires")]
        public IActionResult GetPatientQuestionnaires(string receptionid)
        {
           var QuestionnaireInformationDto = questionnaireService.GetPatientQuestionnaire(receptionid);
            return Ok(QuestionnaireInformationDto); 
        }

        [HttpPost]
        [Route("AddResult")]
       
        public IActionResult AddResult(PorslineQuestionnaireDto porslineQuestionnaireDto)
        {
          var questionnaireResult = questionnaireService.AddQuestionnaireResult(porslineQuestionnaireDto);
            return Ok(questionnaireResult);
        }
    }
}
