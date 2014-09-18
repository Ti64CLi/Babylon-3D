// --------------------------------------------------------------------------------------------------------------------
// <copyright file="extras.structs.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using BABYLON.Internals;

    using Web;

    /// <summary>
    /// </summary>
    public class MinMax
    {
        /// <summary>
        /// </summary>
        public Vector3 maximum { get; set; }

        /// <summary>
        /// </summary>
        public Vector3 minimum { get; set; }
    }

    /// <summary>
    /// </summary>
    public struct Extents
    {
        /// <summary>
        /// </summary>
        public double max { get; set; }

        /// <summary>
        /// </summary>
        public double min { get; set; }
    }

    /// <summary>
    /// </summary>
    public struct MinMaxDistance
    {
        /// <summary>
        /// </summary>
        public double distance { get; set; }

        /// <summary>
        /// </summary>
        public Vector3 maximum { get; set; }

        /// <summary>
        /// </summary>
        public Vector3 minimum { get; set; }
    }

    /// <summary>
    /// </summary>
    public struct Size
    {
        /// <summary>
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// </summary>
        public int width { get; set; }
    }

    /// <summary>
    /// </summary>
    public struct SizeI
    {
        /// <summary>
        /// </summary>
        public int h { get; set; }

        /// <summary>
        /// </summary>
        public int w { get; set; }
    }

    /// <summary>
    /// </summary>
    public struct EffectBaseName
    {
        /// <summary>
        /// </summary>
        public string baseName { get; set; }

        /// <summary>
        /// </summary>
        public string fragment { get; set; }

        /// <summary>
        /// </summary>
        public string fragmentElement { get; set; }

        /// <summary>
        /// </summary>
        public string vertex { get; set; }

        /// <summary>
        /// </summary>
        public string vertexElement { get; set; }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.baseName;
        }
    }

    /// <summary>
    /// </summary>
    public struct MinMagFilter
    {
        /// <summary>
        /// </summary>
        public int mag { get; set; }

        /// <summary>
        /// </summary>
        public int min { get; set; }
    }

    /// <summary>
    /// </summary>
    public struct RootResult
    {
        /// <summary>
        /// </summary>
        public bool found { get; set; }

        /// <summary>
        /// </summary>
        public double root { get; set; }
    }

    /// <summary>
    /// </summary>
    public class PositionCoord
    {
        /// <summary>
        /// </summary>
        public int x { get; set; }

        /// <summary>
        /// </summary>
        public int y { get; set; }
    }

    /// <summary>
    /// </summary>
    public struct EventDts
    {
        /// <summary>
        /// </summary>
        public EventListener handler { get; set; }

        /// <summary>
        /// </summary>
        public string name { get; set; }
    }

    /// <summary>
    /// </summary>
    public class Cache
    {
        /// <summary>
        /// </summary>
        public double? alpha { get; set; }

        /// <summary>
        /// </summary>
        public double aspectRatio { get; set; }

        /// <summary>
        /// </summary>
        public double? beta { get; set; }

        /// <summary>
        /// </summary>
        public double fov { get; set; }

        /// <summary>
        /// </summary>
        public bool localMatrixUpdated { get; set; }

        /// <summary>
        /// </summary>
        public double maxZ { get; set; }

        /// <summary>
        /// </summary>
        public double minZ { get; set; }

        /// <summary>
        /// </summary>
        public int mode { get; set; }

        /// <summary>
        /// </summary>
        public double? orthoBottom { get; set; }

        /// <summary>
        /// </summary>
        public double? orthoLeft { get; set; }

        /// <summary>
        /// </summary>
        public double? orthoRight { get; set; }

        /// <summary>
        /// </summary>
        public double? orthoTop { get; set; }

        /// <summary>
        /// </summary>
        public Node parent { get; set; }

        /// <summary>
        /// </summary>
        public bool pivotMatrixUpdated { get; set; }

        /// <summary>
        /// </summary>
        public Vector3 position { get; set; }

        /// <summary>
        /// </summary>
        public double? radius { get; set; }

        /// <summary>
        /// </summary>
        public int renderHeight { get; set; }

        /// <summary>
        /// </summary>
        public int renderWidth { get; set; }

        /// <summary>
        /// </summary>
        public Vector3 rotation { get; set; }

        /// <summary>
        /// </summary>
        public Quaternion rotationQuaternion { get; set; }

        /// <summary>
        /// </summary>
        public Vector3 scaling { get; set; }

        /// <summary>
        /// </summary>
        public Vector3 target { get; set; }

        /// <summary>
        /// </summary>
        public Vector3 upVector { get; set; }
    }

    /// <summary>
    /// </summary>
    public class EngineOptions
    {
        /// <summary>
        /// </summary>
        public bool antialias { get; set; }
    }

    /// <summary>
    /// </summary>
    public class ShaderMaterialOptions
    {
        /// <summary>
        /// </summary>
        public Array<string> attributes { get; set; }

        /// <summary>
        /// </summary>
        public bool needAlphaBlending { get; set; }

        /// <summary>
        /// </summary>
        public bool needAlphaTesting { get; set; }

        /// <summary>
        /// </summary>
        public Array<string> samplers { get; set; }

        /// <summary>
        /// </summary>
        public Array<string> uniforms { get; set; }
    }

    /// <summary>
    /// </summary>
    public class RenderTargetTextureOptions
    {
        /// <summary>
        /// </summary>
        public bool? generateDepthBuffer { get; set; }

        /// <summary>
        /// </summary>
        public bool? generateMipMaps { get; set; }

        /// <summary>
        /// </summary>
        public int? samplingMode { get; set; }
    }

    /// <summary>
    /// </summary>
    public class TGAHeader
    {
        /// <summary>
        /// </summary>
        public int colormap_index { get; set; }

        /// <summary>
        /// </summary>
        public int colormap_length { get; set; }

        /// <summary>
        /// </summary>
        public byte colormap_size { get; set; }

        /// <summary>
        /// </summary>
        public byte colormap_type { get; set; }

        /// <summary>
        /// </summary>
        public byte flags { get; set; }

        /// <summary>
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// </summary>
        public byte id_length { get; set; }

        /// <summary>
        /// </summary>
        public byte image_type { get; set; }

        /// <summary>
        /// </summary>
        public Array<int> origin { get; set; }

        /// <summary>
        /// </summary>
        public byte pixel_size { get; set; }

        /// <summary>
        /// </summary>
        public int width { get; set; }
    }

    /// <summary>
    /// </summary>
    public class DDSInfoDts : DDSInfo
    {
        /// <summary>
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// </summary>
        public bool isCube { get; set; }

        /// <summary>
        /// </summary>
        public bool isFourCC { get; set; }

        /// <summary>
        /// </summary>
        public bool isLuminance { get; set; }

        /// <summary>
        /// </summary>
        public bool isRGB { get; set; }

        /// <summary>
        /// </summary>
        public int mipmapCount { get; set; }

        /// <summary>
        /// </summary>
        public int width { get; set; }
    }

    /// <summary>
    /// </summary>
    public class TriggerOptions
    {
        /// <summary>
        /// </summary>
        public AbstractMesh parameter { get; set; }

        /// <summary>
        /// </summary>
        public int trigger { get; set; }
    }

    /// <summary>
    /// </summary>
    public class InstancedMeshes
    {
        /// <summary>
        /// </summary>
        private readonly Map<int, Array<InstancedMesh>> items;

        /// <summary>
        /// </summary>
        public InstancedMeshes()
        {
            this.items = new Map<int, Array<InstancedMesh>>();
        }

        /// <summary>
        /// </summary>
        /// <param name="renderId">
        /// </param>
        /// <returns>
        /// </returns>
        public Array<InstancedMesh> this[int renderId]
        {
            get
            {
                return this.items[renderId];
            }

            set
            {
                this.items[renderId] = value;
            }
        }

        /// <summary>
        /// </summary>
        public int defaultRenderId { get; set; }

        /// <summary>
        /// </summary>
        public int selfDefaultRenderId { get; set; }
    }
}