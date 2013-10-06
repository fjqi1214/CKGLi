using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace DAL
{
    public class RecoverHandler
    {

        public static void RecoverError(Action done, Action doRecovery)
        {
            try
            {
                 done();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
               
            }
            catch (ProviderIncompatibleException ex)
            {
                throw;
               
            }
            catch (DbUpdateException ex)
            {
                doRecovery();
                throw;
               
            }
            catch (InvalidOperationException ex)
            {
              
            }
            finally
            {
               
              
            }
          
           
         
        }
    }


}
