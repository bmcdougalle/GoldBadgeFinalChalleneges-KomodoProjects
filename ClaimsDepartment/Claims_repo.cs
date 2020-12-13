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
        public Queue<Claims> ViewClaims()
        {
           return _Claims;
        }
        //update

        public bool UpdateClaim(int claimId, Claims claim)
        {
            Claims oldClaim = GetClaimByID(claimId);
            if(oldClaim != null)
            {
                oldClaim.ClaimID = claim.ClaimID;
                oldClaim.TypeOfClaim = claim.TypeOfClaim;
                oldClaim.ClaimAmount = claim.ClaimAmount;
                oldClaim.DateOfIncident = claim.DateOfIncident;
                oldClaim.DateOfClaim = claim.DateOfClaim;
                oldClaim.IsValid = claim.IsValid;

                return true;
            }
            else
            {
                return false;
            }
        }
        //delete
        public bool RemoveClaim(int claimId)
        {
            Claims claim = GetClaimByID(claimId);
            if(claim == null)
            {
                return false;
            }

            int initialCount = _Claims.Count;
            _Claims.Dequeue();

            if(initialCount > _Claims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //helper
        public Claims GetClaimByID(int claimId)
        {
            foreach (var claim in _Claims)
            {
                if(claim.ClaimID == claimId)
                {
                    return claim;
                   
                }
            }
            return null;
        }

    }
}
