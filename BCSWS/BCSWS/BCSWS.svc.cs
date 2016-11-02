using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;


namespace BCSWS
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class BCSWS : IService
    {

        public BCSWS()
        {
        }

        // 0
        public string[] Login(string termId, DateTime execDT, string langId, string PIN)
        {
            List<object> objs = new List<object>(5);
            objs.Add(0);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            return AxProcesses.call(objs);
        }

        // 1
        public string[] PalletMove(string termId, DateTime execDT, string langId, string PIN, string palletId, string WareHouseId, string LocationId)
	    {
		    List<object> objs = new List<object>(8);
		    objs.Add(1);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(palletId);
		    objs.Add(WareHouseId);
		    objs.Add(LocationId);
		    return AxProcesses.call(objs);
	    }

        // 43
        public string[] InventCountingFindOrCreateJournal(string termId, DateTime execDT, string langId, string PIN, string warehouseId)
        {
            List<object> objs = new List<object>(6);
            objs.Add(43);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(warehouseId);
            return AxProcesses.call(objs);
        }

        // 44
        public string[] InventCountingCreateLine(string termId, DateTime execDT, string langId, string PIN, string journalId, string itemId, string palletId, string batchId, string inventLocationId, string wmsLocationId, double qtyCounted, string UnitID, string PalletBlockingCodeId, string OverwritePalletRecord)
        {
            List<object> objs = new List<object>(15);
            objs.Add(44);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(journalId);
            objs.Add(itemId);
            objs.Add(palletId);
            objs.Add(batchId);
            objs.Add(inventLocationId);
            objs.Add(wmsLocationId);
            objs.Add(qtyCounted);
            objs.Add(UnitID);
            objs.Add(PalletBlockingCodeId);
            objs.Add(OverwritePalletRecord);
            return AxProcesses.call(objs);
        }

        // 46
        public string[] PalletInfo(string termId, DateTime execDT, string langId, string PIN, string palletId)
	    {
		    List<object> objs = new List<object>(6);
		    objs.Add(46);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(palletId);
		    return AxProcesses.call(objs);
	    }

        // 20
        public string[] BlockingCodeList(string termId, DateTime execDT, string langId, string PIN)
        {
            List<object> objs = new List<object>(5);
            objs.Add(20);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            return AxProcesses.call(objs);
        }

        // 21
        public string[] BlockPallet(string termId, DateTime execDT, string langId, string PIN, string palletId, string blockingCode)
        {
            List<object> objs = new List<object>(7);
            objs.Add(21);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(palletId);
            objs.Add(blockingCode);
            return AxProcesses.call(objs);
        }

        // 22
        public string[] UnBlockPallet(string termId, DateTime execDT, string langId, string PIN, string palletId, string blockingCode)
        {
            List<object> objs = new List<object>(5);
            objs.Add(22);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(palletId);
            objs.Add(blockingCode);
            return AxProcesses.call(objs);
        }

        // 13
        public string[] CompletePalleteTransport(string termId, DateTime execDT, string langId, string PIN, string palletId, string WareHouseId, string LocationId)
        {
            List<object> objs = new List<object>(8);
            objs.Add(13);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(palletId);
            objs.Add(WareHouseId);
            objs.Add(LocationId);
            return AxProcesses.call(objs);
        }

        // 10
        public string[] PalletTransportList(string termId, DateTime execDT, string langId, string PIN, string ForkLiftId, int TransportType)
        {
		    List<object> objs = new List<object>(7);
		    objs.Add(10);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(ForkLiftId);
		    objs.Add(TransportType);
		    return AxProcesses.call(objs);
	    }

        // 30
        public string[] RegisterPallet(string termId, DateTime execDT, string langId, string PIN, string ProdId, string PalletId, double Qty)
        {
            List<object> objs = new List<object>(8);
		    objs.Add(30);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(ProdId);
		    objs.Add(PalletId);
		    objs.Add(Qty);
		    return AxProcesses.call(objs);
        }

        // 11
        public string[] SelectBlockPalletTransport(string termId, DateTime execDT, string langId, string PIN, string palletId)
        {
            List<object> objs = new List<object>(6);
		    objs.Add(11);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(palletId);
		    return AxProcesses.call(objs);
        }

        // 12
        public string[] StartPalletTransport(string termId, DateTime execDT, string langId, string PIN, string palletId, string transportId)
        {
            List<object> objs = new List<object>(7);
		    objs.Add(12);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(palletId);
		    objs.Add(transportId);
		    return AxProcesses.call(objs);
        }

        // 41
        public string[] PickingListPicking(string termId, DateTime execDT, string langId, string PIN, string PickingListId, string InventTransId, string ItemId, string ConfigID, string WarehouseId, string LocationId, string PalletId, string BatchId, double Quantity, string UnitId, bool AllowCrossCheck, string refIdTransferTo)
        {
            List<object> objs = new List<object>();
            objs.Add(41);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(PickingListId);
            objs.Add(InventTransId);
            objs.Add(ItemId);
            objs.Add(ConfigID);
            objs.Add(WarehouseId);
            objs.Add(LocationId);
            objs.Add(PalletId);
            objs.Add(BatchId);
            objs.Add(Quantity);
            objs.Add(UnitId);
            objs.Add(AllowCrossCheck);
            objs.Add(refIdTransferTo);
            return AxProcesses.call(objs);
        }

        // 42
        public string[] RegisterInventory(string termId, DateTime execDT, string langId, string PIN, string InventRefType, string InventRefId, string ItemId, string ConfigID, string WarehouseId, string LocationId, string PalletId, string BatchId, double Quantity, string UnitId)
        {
            List<object> objs = new List<object>();
            objs.Add(42);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(InventRefType);
            objs.Add(InventRefId);
            objs.Add(ItemId);
            objs.Add(ConfigID);
            objs.Add(WarehouseId);
            objs.Add(LocationId);
            objs.Add(PalletId);
            objs.Add(BatchId);
            objs.Add(Quantity);
            objs.Add(UnitId);
            return AxProcesses.call(objs);
        }

        // 47
        public string[] InventPickPalletInfo(string termId, DateTime execDT, string langId, string PIN, string InventTransRefId, string palletId)
        {
            List<object> objs = new List<object>();
            objs.Add(47);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(InventTransRefId);
            objs.Add(palletId);
            return AxProcesses.call(objs);
        }

        // 48
        public string[] PalletLoad(string termId, DateTime execDT, string langId, string PIN, string WarehouseId, string LocationId, string PalletId)
        {
            List<object> objs = new List<object>();
            objs.Add(48);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(WarehouseId);
            objs.Add(LocationId);
            objs.Add(PalletId);
            return AxProcesses.call(objs);
        }

        // 49
        public string[] PalletUnload(string termId, DateTime execDT, string langId, string PIN, string WarehouseId, string LocationId, string PalletId)
        {
            List<object> objs = new List<object>();
            objs.Add(49);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(WarehouseId);
            objs.Add(LocationId);
            objs.Add(PalletId);
            return AxProcesses.call(objs);
        }

        // 50
        public string[] PalletLoadList(string termId, DateTime execDT, string langId, string PIN, string WarehouseId, string LocationId)
        {
            List<object> objs = new List<object>();
            objs.Add(50);
            objs.Add(termId);
            objs.Add(execDT);
            objs.Add(langId);
            objs.Add(PIN);
            objs.Add(WarehouseId);
            objs.Add(LocationId);
            return AxProcesses.call(objs);
        }
    }
}