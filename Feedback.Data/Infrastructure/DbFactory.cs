using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        FeedbackContext dbContext;

        public FeedbackContext Init()
        {
            return dbContext ?? (dbContext = new FeedbackContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
