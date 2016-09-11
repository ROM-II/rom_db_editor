using System;
using System.Linq;
using System.Text;
using Runes.Net.Shared.Html;

namespace RunesDataBase
{
    //db.UI_ShowHTML(RunesDataBase.RomDBDebug.ReportErrors(db));
   public static class RomDBDebug
    {
       public static string ReportErrors(SubScript.RunesDataBase db)
       {
           var sophia = db.NPCs.FirstOrDefault(npc => npc.Name == "София");
           if (sophia == null)
                return "Cannot find Sophia";

           var dbtable = sophia.OwnerTable.Db.NpcTable.File.FieldNames;
           var sb = new StringBuilder();
           foreach (var prop in sophia.GetType().GetProperties())
           {
               if (!prop.CanRead) continue;
               try
               {
                   var o = prop.GetValue(sophia);
               }
               catch (Exception e)
               {
                   sb.AppendFormat("[{0}] - {1} - {2}".HtmlWrap("p"), prop.Name, e.Message);
               }
           }
           return sb.ToString();
       }
    }
}
