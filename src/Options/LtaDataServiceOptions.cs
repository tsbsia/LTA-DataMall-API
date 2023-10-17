namespace TsbSia.LtaDataMallApi.Options
{
    public class LtaDataServiceOptions
    {
        public const string SectionName = "LtaDataService";

        public LtaDataServiceOptions()
        {
            BaseUrl = "http://datamall2.mytransport.sg/ltaodataservice";
            AccountKey = string.Empty;
        }

        /// <summary>
        /// The path to save the DLL file of the CNC controller driver 
        /// </summary>
        public string BaseUrl { get; set; }

        public string AccountKey { get; set; }
    }
}
