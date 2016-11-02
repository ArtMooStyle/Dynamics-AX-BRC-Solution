using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BCSWS
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IService
    {
        // 0
        [OperationContract]
        string[] Login(string termId, DateTime execDT, string langId, string PIN);

        // 1
	    [OperationContract]
        string[] PalletMove(string termId, DateTime execDT, string langId, string PIN, string palletId, string WareHouseId, string LocationId);

        // 43
        [OperationContract]
        string[] InventCountingFindOrCreateJournal(string termId, DateTime execDT, string langId, string PIN, string warehouseId);

        // 44
        [OperationContract]
        string[] InventCountingCreateLine(string termId, DateTime execDT, string langId, string PIN, string journalId, string itemId, string palletId, string batchId, string inventLocationId, string wmsLocationId, double qtyCounted, string UnitID, string PalletBlockingCodeId, string OverwritePalletRecord);

        // 46
	    [OperationContract]
        string[] PalletInfo(string termId, DateTime execDT, string langId, string PIN, string palletId);

        // 20
        [OperationContract]
        string[] BlockingCodeList(string termId, DateTime execDT, string langId, string PIN);

        // 21
        [OperationContract]
        string[] BlockPallet(string termId, DateTime execDT, string langId, string PIN, string palletId, string blockingCode);

        // 22
        [OperationContract]
        string[] UnBlockPallet(string termId, DateTime execDT, string langId, string PIN, string palletId, string blockingCode);

        // 13
        [OperationContract]
        string[] CompletePalleteTransport(string termId, DateTime execDT, string langId, string PIN, string palletId, string WareHouseId, string LocationId);

        // 10
        [OperationContract]
        string[] PalletTransportList(string termId, DateTime execDT, string langId, string PIN, string ForkLiftId, int TransportType);

        // 30
        [OperationContract]
        string[] RegisterPallet(string termId, DateTime execDT, string langId, string PIN, string ProdId, string PalletId, double Qty);

        // 11
        [OperationContract]
        string[] SelectBlockPalletTransport(string termId, DateTime execDT, string langId, string PIN, string palletId);

        // 12
        [OperationContract]
        string[] StartPalletTransport(string termId, DateTime execDT, string langId, string PIN, string palletId, string transportId);

        // 41
        [OperationContract]
        string[] PickingListPicking(string termId, DateTime execDT, string langId, string PIN, string PickingListId, string InventTransId, string ItemId, string ConfigID, string WarehouseId, string LocationId, string PalletId, string BatchId, double Quantity, string UnitId, bool AllowCrossCheck, string refIdTransferTo);

        // 42
        [OperationContract]
        string[] RegisterInventory(string termId, DateTime execDT, string langId, string PIN, string InventRefType, string InventRefId, string ItemId, string ConfigID, string WarehouseId, string LocationId, string PalletId, string BatchId, double Quantity, string UnitId);

        // 47
        [OperationContract]
        string[] InventPickPalletInfo(string termId, DateTime execDT, string langId, string PIN, string InventTransRefId, string palletId);

        // 48
        [OperationContract]
        string[] PalletLoad(string termId, DateTime execDT, string langId, string PIN, string WarehouseId, string LocationId, string PalletId);

        // 49
        [OperationContract]
        string[] PalletUnload(string termId, DateTime execDT, string langId, string PIN, string WarehouseId, string LocationId, string PalletId);

        // 50
        [OperationContract]
        string[] PalletLoadList(string termId, DateTime execDT, string langId, string PIN, string WarehouseId, string LocationId);

    }
}