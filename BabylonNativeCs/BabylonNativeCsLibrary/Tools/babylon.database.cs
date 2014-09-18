// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.database.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /// <summary>
    /// </summary>
    public partial class Database
    {
        /*
        private System.Func<object, object> callbackManifestChecked;
        private string currentSceneUrl;
        private IDBDatabase db;
        private bool enableSceneOffline;
        private bool enableTexturesOffline;
        private double manifestVersionFound;
        private bool mustUpdateRessources;
        private bool hasReachedQuota;
        private bool isSupported;
        private IDBFactory idbFactory = (IDBFactory)window.indexedDB;

        private static Web.Document document;
        private static Web.Window window;

        static bool isUASupportingBlobStorage = true;
        public Database(string urlToScene, System.Func<object, object> callbackManifestChecked)
        {
            this.callbackManifestChecked = callbackManifestChecked;
            this.currentSceneUrl = BABYLON.Database.ReturnFullUrlLocation(urlToScene);
            this.db = null;
            this.enableSceneOffline = false;
            this.enableTexturesOffline = false;
            this.manifestVersionFound = 0;
            this.mustUpdateRessources = false;
            this.hasReachedQuota = false;
            this.checkManifestFile();
        }
        static string parseURL(object url)
        {
            var a = document.createElement("a");
            a.href = url;
            var fileName = url.Substring(url.LastIndexOf("/") + 1, url.Length);
            var absLocation = url.Substring(0, url.IndexOf(fileName, 0));
            return absLocation;
        }

        static string ReturnFullUrlLocation(object url)
        {
            if (url.IndexOf("http:/") == -1) {
                return (BABYLON.Database.parseURL(window.location.href) + url);
            } else {
                return url;
            }
        }

        public virtual void checkManifestFile()
        {
            var that = this;
            var manifestURL = this.currentSceneUrl + ".manifest";
            var xhr = new XMLHttpRequest();
            var manifestURLTimeStamped = manifestURL + ((new Regex(@"\?").Match(manifestURL).Success) ? "?" : "&") + (new Date()).getTime();
            xhr.open("GET", manifestURLTimeStamped, true);
            xhr.addEventListener("load", () {
                if (xhr.status == 200 || BABYLON.Tools.ValidateXHRData(xhr, 1)) {
                    try {
                        var manifestFile = JSON.parse(xhr.response);
                        that.enableSceneOffline = manifestFile.enableSceneOffline;
                        that.enableTexturesOffline = manifestFile.enableTexturesOffline;
                        if (manifestFile.version && !isNaN(parseInt(manifestFile.version))) {
                            that.manifestVersionFound = manifestFile.version;
                        }
                        if (that.callbackManifestChecked) {
                            that.callbackManifestChecked(true);
                        }
                    } catch (Exception ex) {
                        noManifestFile();
                    }
                } else {
                    noManifestFile();
                }
            }, false);
            xhr.addEventListener("error", (object _event) {
                noManifestFile();
            }, false);
            try {
                xhr.send();
            } catch (Exception ex) {
                BABYLON.Tools.Error("Error on XHR send request.");
                that.callbackManifestChecked(false);
            }
        }
        public virtual void openAsync(object successCallback, object errorCallback)
        {
            var that = this;
            if (!this.idbFactory || !(this.enableSceneOffline || this.enableTexturesOffline)) {
                this.isSupported = false;
                if (errorCallback)
                    errorCallback();
            } else {
                if (!this.db) {
                    this.hasReachedQuota = false;
                    this.isSupported = true;
                    var request = this.idbFactory.open("babylonjs", 1);
                    request.onerror = (object _event) {
                        handleError();
                    };
                    request.onblocked = (object _event) {
                        BABYLON.Tools.Error("IDB request blocked. Please reload the page.");
                        handleError();
                    };
                    request.onsuccess = (object _event) {
                        that.db = request.result;
                        successCallback();
                    };
                    request.onupgradeneeded = (IDBVersionChangeEvent _event) {
                        that.db = ((object)(_event.target)).result;
                        try {
                            if (_event.oldVersion > 0) {
                                that.db.deleteObjectStore("scenes");
                                that.db.deleteObjectStore("versions");
                                that.db.deleteObjectStore("textures");
                            }
                            var scenesStore = that.db.createObjectStore("scenes", new {});
                            var versionsStore = that.db.createObjectStore("versions", new {});
                            var texturesStore = that.db.createObjectStore("textures", new {});
                        } catch (Exception ex) {
                            BABYLON.Tools.Error("Error while creating object stores. Exception: " + ex.message);
                            handleError();
                        }
                    };
                } else {
                    if (successCallback)
                        successCallback();
                }
            }
        }
        public virtual void loadImageFromDB(string url, HTMLImageElement image)
        {
            var that = this;
            var completeURL = BABYLON.Database.ReturnFullUrlLocation(url);
            Action saveAndLoadImage = () =>
            {
                if (!that.hasReachedQuota && that.db != null)
                {
                    that._saveImageIntoDBAsync(completeURL, image);
                }
                else
                {
                    image.src = url;
                }
            };
            if (!this.mustUpdateRessources)
            {
                this._loadImageFromDBAsync(completeURL, image, saveAndLoadImage);
            }
            else
            {
                saveAndLoadImage();
            }
        }
        private void _loadImageFromDBAsync(string url, HTMLImageElement image, System.Action notInDBCallback)
        {
            if (this.isSupported && this.db != null) {
                var texture;
                var transaction = this.db.transaction(new Array < object > ("textures"));
                transaction.onabort = (object _event) {
                    image.src = url;
                };
                transaction.oncomplete = (object _event) {
                    var blobTextureURL;
                    if (texture) {
                        var URL = window.URL || window.webkitURL;
                        blobTextureURL = URL.createObjectURL(texture.data, new {});
                        image.onerror = () {
                            BABYLON.Tools.Error("Error loading image from blob URL: " + blobTextureURL + " switching back to web url: " + url);
                            image.src = url;
                        };
                        image.src = blobTextureURL;
                    } else {
                        notInDBCallback();
                    }
                };
                var getRequest = transaction.objectStore("textures").get(url);
                getRequest.onsuccess = (object _event) {
                    texture = ((object)(_event.target)).result;
                };
                getRequest.onerror = (object _event) {
                    BABYLON.Tools.Error("Error loading texture " + url + " from DB.");
                    image.src = url;
                };
            } else {
                BABYLON.Tools.Error("Error: IndexedDB not supported by your browser or BabylonJS Database is not open.");
                image.src = url;
            }
        }
        private void _saveImageIntoDBAsync(string url, HTMLImageElement image)
        {
            if (this.isSupported) {
                var generateBlobUrl = () {
                    var blobTextureURL;
                    if (blob) {
                        var URL = window.URL || window.webkitURL;
                        try {
                            blobTextureURL = URL.createObjectURL(blob, new {});
                        } catch (Exception ex) {
                            blobTextureURL = URL.createObjectURL(blob);
                        }
                    }
                    image.src = blobTextureURL;
                };
                if (BABYLON.Database.isUASupportingBlobStorage) {
                    var that = this;
                    var xhr = new XMLHttpRequest();
                    var blob;
                    xhr.open("GET", url, true);
                    xhr.responseType = "blob";
                    xhr.addEventListener("load", () {
                        if (xhr.status == 200) {
                            blob = xhr.response;
                            var transaction = that.db.transaction(new Array < object > ("textures"), "readwrite");
                            transaction.onabort = (object _event) {
                                try {
                                    if (_event.srcElement.error.name == "QuotaExceededError") {
                                        that.hasReachedQuota = true;
                                    }
                                } catch (Exception ex) {}
                                generateBlobUrl();
                            };
                            transaction.oncomplete = (object _event) {
                                generateBlobUrl();
                            };
                            var newTexture = new {};
                            try {
                                var addRequest = transaction.objectStore("textures").put(newTexture);
                                addRequest.onsuccess = (object _event) {};
                                addRequest.onerror = (object _event) {
                                    generateBlobUrl();
                                };
                            } catch (Exception ex) {
                                if (ex.code == 25) {
                                    BABYLON.Database.isUASupportingBlobStorage = false;
                                }
                                image.src = url;
                            }
                        } else {
                            image.src = url;
                        }
                    }, false);
                    xhr.addEventListener("error", (object _event) {
                        BABYLON.Tools.Error("Error in XHR request in BABYLON.Database.");
                        image.src = url;
                    }, false);
                    xhr.send();
                } else {
                    image.src = url;
                }
            } else {
                BABYLON.Tools.Error("Error: IndexedDB not supported by your browser or BabylonJS Database is not open.");
                image.src = url;
            }
        }
        private void _checkVersionFromDB(string url, object versionLoaded)
        {
            var that = this;
            var updateVersion = (object _event) {
                that._saveVersionIntoDBAsync(url, versionLoaded);
            };
            this._loadVersionFromDBAsync(url, versionLoaded, updateVersion);
        }
        private void _loadVersionFromDBAsync(string url, object callback, object updateInDBCallback)
        {
            if (this.isSupported) {
                var version;
                var that = this;
                try {
                    var transaction = this.db.transaction(new Array < object > ("versions"));
                    transaction.oncomplete = (object _event) {
                        if (version) {
                            if (that.manifestVersionFound > version.data) {
                                that.mustUpdateRessources = true;
                                updateInDBCallback();
                            } else {
                                callback(version.data);
                            }
                        } else {
                            that.mustUpdateRessources = true;
                            updateInDBCallback();
                        }
                    };
                    transaction.onabort = (object _event) {
                        callback(-1);
                    };
                    var getRequest = transaction.objectStore("versions").get(url);
                    getRequest.onsuccess = (object _event) {
                        version = ((object)(_event.target)).result;
                    };
                    getRequest.onerror = (object _event) {
                        BABYLON.Tools.Error("Error loading version for scene " + url + " from DB.");
                        callback(-1);
                    };
                } catch (Exception ex) {
                    BABYLON.Tools.Error("Error while accessing 'versions' object store (READ OP). Exception: " + ex.message);
                    callback(-1);
                }
            } else {
                BABYLON.Tools.Error("Error: IndexedDB not supported by your browser or BabylonJS Database is not open.");
                callback(-1);
            }
        }
        private void _saveVersionIntoDBAsync(string url, object callback)
        {
            if (this.isSupported && !this.hasReachedQuota) {
                var that = this;
                try {
                    var transaction = this.db.transaction(new Array < object > ("versions"), "readwrite");
                    transaction.onabort = (object _event) {
                        try {
                            if (_event.srcElement.error.name == "QuotaExceededError") {
                                that.hasReachedQuota = true;
                            }
                        } catch (Exception ex) {}
                        callback(-1);
                    };
                    transaction.oncomplete = (object _event) {
                        callback(that.manifestVersionFound);
                    };
                    var newVersion = new {};
                    var addRequest = transaction.objectStore("versions").put(newVersion);
                    addRequest.onsuccess = (object _event) {};
                    addRequest.onerror = (object _event) {
                        BABYLON.Tools.Error("Error in DB add version request in BABYLON.Database.");
                    };
                } catch (Exception ex) {
                    BABYLON.Tools.Error("Error while accessing 'versions' object store (WRITE OP). Exception: " + ex.message);
                    callback(-1);
                }
            } else {
                callback(-1);
            }

            throw new NotImplementedException();
        }
        private void loadFileFromDB(string url, object sceneLoaded, object progressCallBack, object errorCallback, bool useArrayBuffer = false)
        {
            var that = this;
            var completeUrl = BABYLON.Database.ReturnFullUrlLocation(url);
            var saveAndLoadFile = (object _event) {
                that._saveFileIntoDBAsync(completeUrl, sceneLoaded, progressCallBack);
            };
            this._checkVersionFromDB(completeUrl, (object version) {
                if (version != -1) {
                    if (!that.mustUpdateRessources) {
                        that._loadFileFromDBAsync(completeUrl, sceneLoaded, saveAndLoadFile, useArrayBuffer);
                    } else {
                        that._saveFileIntoDBAsync(completeUrl, sceneLoaded, progressCallBack, useArrayBuffer);
                    }
                } else {
                    errorCallback();
                }
            });
        }
        private void _loadFileFromDBAsync(object url, object callback, object notInDBCallback, bool useArrayBuffer = false)
        {
            if (this.isSupported) {
                var targetStore;
                if (url.IndexOf(".babylon") != -1) {
                    targetStore = "scenes";
                } else {
                    targetStore = "textures";
                }
                var file;
                var transaction = this.db.transaction(new Array < object > (targetStore));
                transaction.oncomplete = (object _event) {
                    if (file) {
                        callback(file.data);
                    } else {
                        notInDBCallback();
                    }
                };
                transaction.onabort = (object _event) {
                    notInDBCallback();
                };
                var getRequest = transaction.objectStore(targetStore).get(url);
                getRequest.onsuccess = (object _event) {
                    file = ((object)(_event.target)).result;
                };
                getRequest.onerror = (object _event) {
                    BABYLON.Tools.Error("Error loading file " + url + " from DB.");
                    notInDBCallback();
                };
            } else {
                BABYLON.Tools.Error("Error: IndexedDB not supported by your browser or BabylonJS Database is not open.");
                callback();
            }
        }
        private void _saveFileIntoDBAsync(string url, object callback, object progressCallback, bool useArrayBuffer = false)
        {
            if (this.isSupported) {
                var targetStore;
                if (url.IndexOf(".babylon") != -1) {
                    targetStore = "scenes";
                } else {
                    targetStore = "textures";
                }
                var xhr = new XMLHttpRequest();
                var fileData;
                var that = this;
                xhr.open("GET", url, true);
                if (useArrayBuffer) {
                    xhr.responseType = "arraybuffer";
                }
                xhr.onprogress = progressCallback;
                xhr.addEventListener("load", () {
                    if (xhr.status == 200 || BABYLON.Tools.ValidateXHRData(xhr, (!useArrayBuffer) ? 1 : 6)) {
                        fileData = (!useArrayBuffer) ? xhr.responseText : xhr.response;
                        if (!that.hasReachedQuota) {
                            var transaction = that.db.transaction(new Array < object > (targetStore), "readwrite");
                            transaction.onabort = (object _event) {
                                try {
                                    if (_event.srcElement.error.name == "QuotaExceededError") {
                                        that.hasReachedQuota = true;
                                    }
                                } catch (Exception ex) {}
                                callback(fileData);
                            };
                            transaction.oncomplete = (object _event) {
                                callback(fileData);
                            };
                            var newFile;
                            if (targetStore == "scenes") {
                                newFile = new {};
                            } else {
                                newFile = new {};
                            }
                            try {
                                var addRequest = transaction.objectStore(targetStore).put(newFile);
                                addRequest.onsuccess = (object _event) {};
                                addRequest.onerror = (object _event) {
                                    BABYLON.Tools.Error("Error in DB add file request in BABYLON.Database.");
                                };
                            } catch (Exception ex) {
                                callback(fileData);
                            }
                        } else {
                            callback(fileData);
                        }
                    } else {
                        callback();
                    }
                }, false);
                xhr.addEventListener("error", (object _event) {
                    BABYLON.Tools.Error("error on XHR request.");
                    callback();
                }, false);
                xhr.send();
            } else {
                BABYLON.Tools.Error("Error: IndexedDB not supported by your browser or BabylonJS Database is not open.");
                callback();
            }
        }
        */
    }
}