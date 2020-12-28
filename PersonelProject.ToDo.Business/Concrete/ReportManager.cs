using PersonelProject.ToDo.Business.Interfaces;
using PersonelProject.ToDo.DataAccess.Concrete.EFC.Repositories;
using PersonelProject.ToDo.DataAccess.InterFaces;
using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonelProject.ToDo.Business.Concrete
{
    public class ReportManager : IReportService  
    {
        private readonly IReportBranch _reportBranch ;

        public ReportManager(IReportBranch reportBranch)
        {
            _reportBranch = reportBranch;
        }
        public List<Report> GetirButunu()
        {
            return _reportBranch.GetirButunu();
        }

        public Report GetirIdCalisma(int id)
        {
            return _reportBranch.GetirIdCalisma(id);
        }

        public void Guncelle(Report tablo)
        {
            _reportBranch.Guncelle(tablo);
        }

        public void Kaydet(Report tablo)
        {
            _reportBranch.Kaydet(tablo);
        }

        public void Sil(Report tablo)
        {
            _reportBranch.Sil(tablo);
        }
    }
}
