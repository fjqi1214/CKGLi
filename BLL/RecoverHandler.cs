using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace BLL
{
    public class RecoverHandler
    {

        public static void HandleError(Action done, Action doRecovery, string fileName)
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
                throw;
               
            }
            catch (InvalidOperationException ex)
            {
              
            }
            finally
            {
                doRecovery();
              
            }
         
        }
    }


}
