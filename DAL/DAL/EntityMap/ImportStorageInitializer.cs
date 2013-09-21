using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model;

namespace DAL.EntityMap
{
    public class ImportStorageInitializer
        : DropCreateDatabaseIfModelChanges<CKGLContext>
    {
        protected override void Seed(CKGLContext context)
        {
            var imports = new List<ImportStorage>
            {
                new ImportStorage{ LotNum="lot1", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品1", ProductTime=DateTime.Now, UnitNum=10},
                 new ImportStorage{ LotNum="lot2", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品2", ProductTime=DateTime.Now, UnitNum=10},
                  new ImportStorage{ LotNum="lot3", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品3", ProductTime=DateTime.Now, UnitNum=10},
                   new ImportStorage{ LotNum="lot4", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品4", ProductTime=DateTime.Now, UnitNum=10},
                    new ImportStorage{ LotNum="lot5", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品5", ProductTime=DateTime.Now, UnitNum=10},
                     new ImportStorage{ LotNum="lot6", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品6", ProductTime=DateTime.Now, UnitNum=10},
                      new ImportStorage{ LotNum="lot7", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品7", ProductTime=DateTime.Now, UnitNum=10},
                       new ImportStorage{ LotNum="lot8", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品8", ProductTime=DateTime.Now, UnitNum=10},
                        new ImportStorage{ LotNum="lot9", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品9", ProductTime=DateTime.Now, UnitNum=10},
                         new ImportStorage{ LotNum="lot10", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品10", ProductTime=DateTime.Now, UnitNum=10},
                          new ImportStorage{ LotNum="lot11", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品11", ProductTime=DateTime.Now, UnitNum=10},
                           new ImportStorage{ LotNum="lot12", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品12", ProductTime=DateTime.Now, UnitNum=10},

                           new ImportStorage{ LotNum="lot13", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品13", ProductTime=DateTime.Now, UnitNum=10},
                              new ImportStorage{ LotNum="lot14", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品14", ProductTime=DateTime.Now, UnitNum=10},
                                 new ImportStorage{ LotNum="lot15", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品15", ProductTime=DateTime.Now, UnitNum=10},
                                    new ImportStorage{ LotNum="lot16", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品16", ProductTime=DateTime.Now, UnitNum=10},
                                       new ImportStorage{ LotNum="lot17", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品17", ProductTime=DateTime.Now, UnitNum=10},
                                          new ImportStorage{ LotNum="lot18", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品18", ProductTime=DateTime.Now, UnitNum=10},
                                             new ImportStorage{ LotNum="lot19", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品19", ProductTime=DateTime.Now, UnitNum=10},
                                                new ImportStorage{ LotNum="lot20", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品20", ProductTime=DateTime.Now, UnitNum=10},

                                                   new ImportStorage{ LotNum="lot21", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品21", ProductTime=DateTime.Now, UnitNum=10},
                                          new ImportStorage{ LotNum="lot22", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品22", ProductTime=DateTime.Now, UnitNum=10},
                                          new ImportStorage{ LotNum="lot23", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品23", ProductTime=DateTime.Now, UnitNum=10},
                                       new ImportStorage{ LotNum="lot24", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品24", ProductTime=DateTime.Now, UnitNum=10},
                                          new ImportStorage{ LotNum="lot25", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品25", ProductTime=DateTime.Now, UnitNum=10},
                                             new ImportStorage{ LotNum="lot26", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品26", ProductTime=DateTime.Now, UnitNum=10},
                                                new ImportStorage{ LotNum="lot27", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品27", ProductTime=DateTime.Now, UnitNum=10},

                                                   new ImportStorage{ LotNum="lot24", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品24", ProductTime=DateTime.Now, UnitNum=10},
                                                   new ImportStorage{ LotNum="lot24", ArrivalTime=DateTime.Now, MaterialNo="料号1", Number=100, ProductName="产品24", ProductTime=DateTime.Now, UnitNum=10},
            };

            imports.ForEach(i => context.ImportStorages.Add(i));
            context.SaveChanges();
        }
    }
}
