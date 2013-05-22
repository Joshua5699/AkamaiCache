using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Akamai
{
    public class RemoveItems
    {

        private Domain _Domain { get; set; }
        private PurgeType _PurgeType { get; set; }
        private Action _Action { get; set; }
        private string[] _ItemsToPurge { get; set; }
        private string _AkamaiAccountName { get; set; }
        private string _AkamaiAccountPassword { get; set; }
        private string _AkamaiNotificationEmail { get; set; }




        /// <summary>
        /// Email addresses passed via this property will recieve notice (from Akamai) that the request has been submitted and notice when it's complete
        /// </summary>
        public string AkamaiNotificationEmail
        {
            get
            {
                return _AkamaiNotificationEmail;
            }
            set
            {
                _AkamaiNotificationEmail = value;
            }
        }



        /// <summary>
        /// Password of the Akamai account.
        /// </summary>
        public string AkamaiAccountPassword
        {
            get
            {
                return _AkamaiAccountPassword;
            }
            set
            {
                _AkamaiAccountPassword = value;
            }
        }

        /// <summary>
        /// Account name used to authenticate with the service and submit the request.
        /// </summary>

        public string AkamaiAccountName
        {
            get
            {
                return _AkamaiAccountName;
            }
            set
            {
                _AkamaiAccountName = value;
            }
        }


        /// <summary>
        /// List of URLs to purge from the cache.
        /// </summary>
        public string[] ItemsToPurge
        {
            get
            {
                return _ItemsToPurge;
            }
            set
            {
                _ItemsToPurge = value;
            }
        }

        /// <summary>
        /// This specifies wether or not to completely remove the item from the Akamai cache or to invalidate it.  
        /// </summary>
        public Action Action
        {
            get
            {
                return _Action;
            }
            set
            {
                _Action = value;
            }
        }

        public Domain Domain
        {
            get
            {
                return _Domain;
            }
            set
            {
                _Domain = value;
            }
        }

        /// <summary>
        /// Specifies wether we're purging a list of URLs or the entire cache.  If this is set co CPCode, then the one and only value in the ItemsToPurge array must be the integer CPcode.
        /// </summary>
        public PurgeType PurgeType
        {
            get
            {
                return _PurgeType;
            }
            set
            {
                _PurgeType = value;
            }
        }


        /// <summary>
        /// This calls the Akamai service and passes all the properties to it.  Calling this will remove items from the cache.
        /// </summary>
        public void Remove()
        {

            if (_PurgeType == PurgeType.ARL)
            {
                if ((!_ItemsToPurge[0].Trim().ToLower().Contains("http://")) || (!_ItemsToPurge[0].Trim().ToLower().Contains("https://")))
                {
                    throw new Exception("If the PurgeType is set to 'ARL', then the items in the ItemsToPurge array must be complete URLs");
                }
            }


            if (_PurgeType == PurgeType.CPCode)
            {
                double Num;
                bool isNum = double.TryParse(_ItemsToPurge[0], out Num);
                if (!isNum) 
                {
                    throw new Exception("If the PurgeType is set to 'CPCode', the the ItemsToPurge array must only contain one item, and that item must be a number");  
                }
            }
            
            string email = "email-notification=" + _AkamaiNotificationEmail;
            string[] fileToPurge = _ItemsToPurge;




            string action = "";
            if (_Action == Action.Purge)
            {
                action = "action=remove";
            }
            else if (_Action == Action.Invalidate)
            {
                action = "action=invalidate";
            }


            ///get the domain
            string domain = "";
            if (_Domain == Domain.Staging)
            {
                domain = "domain=staging";
            }
            else if (_Domain == Domain.Production)
            {
                domain = "domain=production";
            }

            string purgeType = "";
            if (_PurgeType == PurgeType.CPCode)
            {
                purgeType = "type=cpcode";
            }
            else if (_PurgeType == PurgeType.ARL)
            {
                purgeType = "type=arl";
            }

            //type: type=cpcode or type=arl >> arl: akamai resource locator. 
            //url: uniform resource locator. 
            //To use the type cpcode option, your administrator must enable 
            //purge-by-cpcode access for your username 
            //through Akamai EdgeControl. 
            string[] options = new string[] { action, domain, email, purgeType };
            AkamaiCache.AkamaiServiceRef.PurgeApi purgeAPI = new AkamaiCache.AkamaiServiceRef.PurgeApi();
            AkamaiCache.AkamaiServiceRef.PurgeResult purgeResult = purgeAPI.purgeRequest(_AkamaiAccountName, _AkamaiAccountPassword, string.Empty, options, fileToPurge);

            if (purgeResult.resultCode >= 300)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendFormat(" Error Code: {0}", purgeResult.resultCode);
                sb.AppendFormat(" Error Message: {0}", purgeResult.resultMsg);
                sb.AppendFormat(" Session ID: {0}", purgeResult.sessionID);
                sb.AppendFormat(" URI Index: {0}", purgeResult.uriIndex);
                throw new Exception(sb.ToString());
            }
        }


    }
}
