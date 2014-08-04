using System;
using Web;

namespace BABYLON
{
    using BABYLON.Internals;

    public class MinMax
    {
        public Vector3 minimum { get; set; }

        public Vector3 maximum { get; set; }
    }

    public struct Extents
    {
        public double min { get; set; }

        public double max { get; set; }
    }

    public struct MinMaxDistance
    {
        public Vector3 minimum { get; set; }

        public Vector3 maximum { get; set; }

        public double distance { get; set; }
    }

    public struct Size
    {
        public int width { get; set; }

        public int height { get; set; }
    }

    public struct SizeI
    {
        public int w { get; set; }

        public int h { get; set; }
    }

    public struct EffectBaseName
    {
        public string baseName { get; set; }

        public string vertexElement { get; set; }

        public string vertex { get; set; }

        public string fragmentElement { get; set; }

        public string fragment { get; set; }

        public override string ToString()
        {
            return baseName;
        }
    }

    public struct MinMagFilter
    {
        public int min { get; set; }

        public int mag { get; set; }
    }

    public struct RootResult
    {
        public double root { get; set; }

        public bool found { get; set; }
    }

    public class PositionCoord
    {
        public int x { get; set; }

        public int y { get; set; }
    }

    public struct EventDts
    {
        public string name { get; set; }

        public EventListener handler { get; set; }
    }

    public class Cache
    {
        public int mode { get; set; }

        public double minZ { get; set; }

        public double maxZ { get; set; }

        public double fov { get; set; }

        public double aspectRatio { get; set; }

        public double? orthoLeft { get; set; }

        public double? orthoRight { get; set; }

        public double? orthoBottom { get; set; }

        public double? orthoTop { get; set; }

        public int renderWidth { get; set; }

        public int renderHeight { get; set; }

        public bool localMatrixUpdated { get; set; }

        public Vector3 scaling { get; set; }

        public Vector3 rotation { get; set; }

        public Quaternion rotationQuaternion { get; set; }

        public Vector3 position { get; set; }

        public bool pivotMatrixUpdated { get; set; }

        public Node parent { get; set; }

        public Vector3 target { get; set; }

        public double? alpha { get; set; }

        public double? beta { get; set; }

        public double? radius { get; set; }

        public Vector3 upVector { get; set; }
    }

    public class EngineOptions
    {
        public bool antialias { get; set; }
    }

    public class ShaderMaterialOptions
    {
        public bool needAlphaBlending { get; set; }

        public bool needAlphaTesting { get; set; }

        public Array<string> attributes { get; set; }

        public Array<string> uniforms { get; set; }

        public Array<string> samplers { get; set; }
    }

    public class RenderTargetTextureOptions
    {
        public int? samplingMode { get; set; }

        public bool? generateMipMaps { get; set; }

        public bool? generateDepthBuffer { get; set; }
    }

    public class TGAHeader
    {
        public Array<int> origin { get; set; }

        public int width { get; set; }

        public int height { get; set; }

        public byte flags { get; set; }

        public byte id_length { get; set; }

        public byte colormap_type { get; set; }

        public byte image_type { get; set; }

        public int colormap_index { get; set; }

        public int colormap_length { get; set; }

        public byte colormap_size { get; set; }

        public byte pixel_size { get; set; }
    }

    public class DDSInfoDts : DDSInfo
    {
        public int width { get; set; }

        public int height { get; set; }

        public int mipmapCount { get; set; }

        public bool isFourCC { get; set; }

        public bool isRGB { get; set; }

        public bool isLuminance { get; set; }

        public bool isCube { get; set; }
    }

    public class TriggerOptions
    {
        public AbstractMesh parameter { get; set; }

        public int trigger { get; set; }
    }

    public class InstancedMeshes
    {
        private Map<int, Array<InstancedMesh>> items;

        public InstancedMeshes()
        {
            this.items = new Map<int, Array<InstancedMesh>>();
        }

        public int selfDefaultRenderId { get; set; }

        public int defaultRenderId { get; set; }

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
    }
}
