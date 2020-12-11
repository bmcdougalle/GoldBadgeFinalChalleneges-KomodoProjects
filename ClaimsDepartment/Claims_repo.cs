using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsDepartment
{
    public class Claims_repo
    {
       private readonly Queue<Claims> _Claims = new Queue<Claims>();
        //create
        public void AddAClaim(Claims claim)
        {
            _Claims.Enqueue(claim);
        } 
        //read
        public void ShowNextClaim()
        {

        }
        //update
        //delete
    }
}
