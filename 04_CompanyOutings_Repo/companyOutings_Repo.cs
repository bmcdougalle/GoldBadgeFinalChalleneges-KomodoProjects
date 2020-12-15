using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyOutings_Repo
{
    public class companyOutings_Repo
    {
        private readonly List<CompanyOutings> _companyOutings = new List<CompanyOutings>();

        public void AddOuting(CompanyOutings outing)
        {
            _companyOutings.Add(outing);
        }
    }
}
