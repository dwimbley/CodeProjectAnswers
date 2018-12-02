using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howtoadtheabilityforpersonstoselectthebr1267164
{
    public static class IdentityFrameworkExtensions
    {
        public static string GetTransactionId(this IIdentity identity)
        {
            var username = identity.GetUserName();
            var users = userstable.Where(m => m.UserName == username).Select(m => m.Transactions).FirstOrDefault;
            
            if (user == null)
            {
                return "";
            }

            var transId = users.TransactionId;
            return transId;
        }
    }

    public class PseudoCodeForDbAccess
    {
        public ActionResult Index()
        {
            var transactionId = User.Identity.GetTransactionId();
            var model = new MyDataModel();
            model.Build(transactionId);
        }
    }

    public class MyDataModel
    {
        public IEnumerable<string> DbData { get; set; }

        public void Build(string transactionId)
        {
            var mydatainmodel = tableindb.Where(m => m.TransactionId == transactionIdPassedIn).Select(m=>m.StringColumn);

            this.DbData = mydatainmodel;
        }
    }
}
