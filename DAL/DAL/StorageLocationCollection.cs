using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Interface;

namespace DAL
{
    public class StorageLocationCollection : IEnumerable<StorageLocation>
      
    {


        private List<StorageLocation> storageLocations;
        public StorageLocationCollection()
        {
            storageLocations = new List<StorageLocation>();
            storageLocations.Add(new StorageLocation { ProductName = "1", LocationName = "位置1", ManufacturerName = "厂家1" });
            storageLocations.Add(new StorageLocation { ProductName = "2", LocationName = "位置2", ManufacturerName = "厂家2" });
            storageLocations.Add(new StorageLocation { ProductName = "3", LocationName = "位置3", ManufacturerName = "厂家3" });
            storageLocations.Add(new StorageLocation { ProductName = "4", LocationName = "位置4", ManufacturerName = "厂家4" });
            storageLocations.Add(new StorageLocation { ProductName = "5", LocationName = "位置5", ManufacturerName = "厂家5" });
            storageLocations.Add(new StorageLocation { ProductName = "6", LocationName = "位置6", ManufacturerName = "厂家6" });
            storageLocations.Add(new StorageLocation { ProductName = "7", LocationName = "位置7", ManufacturerName = "厂家7" });
            storageLocations.Add(new StorageLocation { ProductName = "8", LocationName = "位置8", ManufacturerName = "厂家8" });
            storageLocations.Add(new StorageLocation { ProductName = "9", LocationName = "位置9", ManufacturerName = "厂家9" });
            storageLocations.Add(new StorageLocation { ProductName = "10", LocationName = "位置10", ManufacturerName = "厂家10" });
            storageLocations.Add(new StorageLocation { ProductName = "11", LocationName = "位置11", ManufacturerName = "厂家11" });
            storageLocations.Add(new StorageLocation { ProductName = "12", LocationName = "位置12", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "13", LocationName = "位置13", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "14", LocationName = "位置14", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "15", LocationName = "位置15", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "16", LocationName = "位置16", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "17", LocationName = "位置17", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "18", LocationName = "位置18", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "19", LocationName = "位置19", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "20", LocationName = "位置20", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "21", LocationName = "位置21", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "22", LocationName = "位置22", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "23", LocationName = "位置23", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "24", LocationName = "位置24", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "25", LocationName = "位置25", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "26", LocationName = "位置26", ManufacturerName = "厂家12" });
            storageLocations.Add(new StorageLocation { ProductName = "27", LocationName = "位置27", ManufacturerName = "厂家12" });

        }

        public List<StorageLocation> StorageLocations { get { return storageLocations; } }

        public IEnumerator<StorageLocation> GetEnumerator()
        {
            return StorageLocations.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return StorageLocations.GetEnumerator();
        }

        public IEnumerable<StorageLocation> MoveNextPage(int pageNum, int size)
        {
            return GetEntities(pageNum, size);
        }

        public IEnumerable<StorageLocation> MovePreviousPage(int pageNum, int size)
        {
            return GetEntities(pageNum, size);
        }

        public IEnumerable<StorageLocation> MoveLastPage(int pageNum, int size)
        {
            return GetEntities(pageNum, size);
        }

        public IEnumerable<StorageLocation> MoveFirstPage(int pageNum, int size)
        {
            return GetEntities(pageNum, size);
        }

        public IEnumerable<StorageLocation> GetEntities(int pageNum, int size)
        {
            return StorageLocations.Skip<StorageLocation>(pageNum * size).Take(size);
        }


        public long GetCount()
        {
           return StorageLocations.Count;
        }
    }
}
