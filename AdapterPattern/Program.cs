using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdapterPattern
{
    class MainApp
    {
        static void Main()
        {
            int i = 0, resp = 0;
            while(i == 0){
                GetPartDetailWithDiscount();
                Console.WriteLine("Enter Any Value to Continue... (0 to quit)");
                Int32.TryParse(Console.ReadLine(), out resp);
                switch(resp){
                    case 1:
                        i = 0;
                        break;
                    case 0:
                        i = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid Input ");
                        break;
                }
            }
        }
        private static void GetPartDetailWithDiscount(){
            Console.Write("Enter Part No : ");
            int PartNo = 0, Discount = 0;
            Int32.TryParse(Console.ReadLine(), out PartNo);
            Console.Write("Enter Discount (1 - 100) : ");
            Int32.TryParse(Console.ReadLine(), out Discount);
            if(PartNo > Discount){
                PartDetailsWithDiscount partDetails = new PartDetailsWithDiscount(PartNo, Discount);
            }
            if(PartNo == 0){
                Console.WriteLine("Enter Valid Part No");
            }
            if(Discount == 0 && Discount > 100){
                Console.WriteLine("Enter Valid Discount");
            }
        }
    }
    
    //BigApplication with Complicated Data Fetching
    //Adaptee
    class DataFetcher
    {
        private PartList _partList{ get; set; }
        public DataFetcher(){
            using(StreamReader sr = new StreamReader("Parts.json")){
                string json = sr.ReadToEnd();
                this._partList = JsonConvert.DeserializeObject<PartList>(json);
            }
        }
        public Part GetPartDetails(int PartId)
        {
            return _partList.Parts.Find(x => x.Id == PartId);
        }
    }

    //Target
    class PartDetails{
        protected int PartId;
        protected double Discount;
        protected Part PartDetail;
        public PartDetails(int PartId, double Discount){
            this.PartId = PartId;
            this.Discount = Discount;
        }
        public virtual void GetPartDetailsWithDiscount(){}
        
    }

    //Adapter
    class PartDetailsWithDiscount : PartDetails{
        private DataFetcher dataFetcher;
        private double PartPriceWithDiscount;
        public PartDetailsWithDiscount(int PartId, double Discount) : base(PartId, Discount){
            GetPartDetailsWithDiscount();
        }
        public override void GetPartDetailsWithDiscount()
        {
            dataFetcher = new DataFetcher();
            PartDetail = dataFetcher.GetPartDetails(PartId);
            if(PartDetail != null){
                Console.WriteLine("Part Name - " + PartDetail.Id.ToString() + ", " + PartDetail.Desc);
                Console.WriteLine("Part Type - " + PartDetail.Type);
                Console.WriteLine("Part UOM - " + PartDetail.UOM);
                GetPartPriceWithDiscount(PartDetail, Discount);
            }else{
                Console.WriteLine("Part Details Not Found For - " + PartId);
            }
        }
        private void GetPartPriceWithDiscount(Part PartDetail, double Discount){
            PartPriceWithDiscount = PartDetail.MRP - (PartDetail.MRP / 100 * Discount);
            Console.WriteLine("Part Amount After Disc Applied - " + PartPriceWithDiscount);
        }
    }
}