using Microsoft.AspNetCore.Razor.TagHelpers;
using PersonelProject.ToDo.Business.Interfaces;
using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.Web1.TagHelpers
{
    [HtmlTargetElement("bringMissionUserId")]
    public class MissionAppUserIdTagHelpers : TagHelper
    {
        private readonly IMissionService _missionService;
        public MissionAppUserIdTagHelpers(IMissionService missionService)
        {
            _missionService = missionService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Mission> missions =_missionService.BringWithUserId(AppUserId);
            int done = missions.Where(I => I.Ozet).Count();
            int notdone = missions.Where(I => !I.Ozet).Count();

            string htmlString = $"<strong>Number of tasks completed </strong> {done} <br> <strong>Number of tasks incompleted </strong> {notdone}";

            output.Content.SetHtmlContent(htmlString);
        
        }

    }
}
