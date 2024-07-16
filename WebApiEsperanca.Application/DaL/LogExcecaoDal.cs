using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEsperanca.Repository;
using WebApiEsperanca.Repository.Models;

namespace WebApiEsperanca.Application.DaL
{
    public static class LogExcecaoDal
    {
        public static void GravaLogExcecao(tabLogExcecao objEnt, Context _ctx)
        {
            try
            {
                objEnt.dataHora = DateTime.Now;
                objEnt.excecao = objEnt.excecao.Replace("'", " ").Trim();
                _ctx.tabLogExcecao.Add(objEnt);
                _ctx.SaveChanges();
            }
            catch (Exception)
            { }
        }
    }
}
