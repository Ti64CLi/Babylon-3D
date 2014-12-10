namespace BABYLON
{
    using System;

    public class NavigatorAdapter : Web.Navigator
    {
        public int maxTouchPoints
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool msManipulationViewsEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int msMaxTouchPoints
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool msPointerEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool pointerEnabled
        {
            get
            {
                return true;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void msLaunchUri(string uri, Web.MSLaunchUriCallback successCallback = null, Web.MSLaunchUriCallback noHandlerCallback = null)
        {
            throw new NotImplementedException();
        }

        public string appName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string appVersion
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string platform
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string product
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string userAgent
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string vendor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool onLine
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string appCodeName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string appMinorVersion
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string browserLanguage
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int connectionSpeed
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool cookieEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string cpuClass
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string language
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.MSMimeTypesCollection mimeTypes
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.MSPluginsCollection plugins
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string systemLanguage
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string userLanguage
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool javaEnabled()
        {
            throw new NotImplementedException();
        }

        public bool taintEnabled()
        {
            throw new NotImplementedException();
        }

        public Web.Geolocation geolocation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string msDoNotTrack
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool confirmSiteSpecificTrackingException(Web.ConfirmSiteSpecificExceptionsInformation args)
        {
            throw new NotImplementedException();
        }

        public bool confirmWebWideTrackingException(Web.ExceptionInformation args)
        {
            throw new NotImplementedException();
        }

        public void removeSiteSpecificTrackingException(Web.ExceptionInformation args)
        {
            throw new NotImplementedException();
        }

        public void removeWebWideTrackingException(Web.ExceptionInformation args)
        {
            throw new NotImplementedException();
        }

        public void storeSiteSpecificTrackingException(Web.StoreSiteSpecificExceptionsInformation args)
        {
            throw new NotImplementedException();
        }

        public void storeWebWideTrackingException(Web.StoreExceptionsInformation args)
        {
            throw new NotImplementedException();
        }

        public bool msSaveBlob(object blob, string defaultName = null)
        {
            throw new NotImplementedException();
        }

        public bool msSaveOrOpenBlob(object blob, string defaultName = null)
        {
            throw new NotImplementedException();
        }
    }
}
