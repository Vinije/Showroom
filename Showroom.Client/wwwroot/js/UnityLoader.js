var progressHandler = null;

var unityInstance = null;

var blazorCanvas = null;

var unityConfig = null;

onProgress = function (progress)
{
    if (progressHandler == null) {
        return;
    }

    progressHandler.invokeMethodAsync("OnProgress", progress);
}

onFinished = function () {
    progressHandler.invokeMethodAsync("OnFinished");
}

CreateUnityInstance = function (canvas, config, handler)
{
    if (handler || unityInstance)
    {
        progressHandler = handler;
        QuitUnityInstance();
    }

    blazorCanvas = canvas;

    unityConfig = config;

    const scripts = document.getElementsByTagName("script");

    var loader = null;

    for (let script in scripts)
    {
        if (Object.prototype.hasOwnProperty.call(scripts, script))
        {
            const source = script.src;

            if (source != null && source.includes("Build.loader.js"))
            {
                loader = node;
            }
        }
    }

    if (loader != null)
    {
        document.removeChild(loader);   
    }

    loader = document.createElement("script");
    document.body.appendChild(loader);
    loader.onload = LoadUnity;
    loader.src = "Builds/" + config.productName + "/Build/Build.loader.js";
}

LoadUnity = function () {
    createUnityInstance(blazorCanvas, unityConfig, onProgress).then((instance) => {
        unityInstance = instance;
        onFinished();
    });
}

QuitUnityInstance = function () {

    if (unityInstance != null)
    {
        unityInstance.Quit();
        unityInstance = null;
    }
}