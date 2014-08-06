// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.csg.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON.CSG
{
    /*
    public partial class Vertex
    {
        public Vector3 pos;
        public Vector3 normal;
        public Vector2 uv;
        public Vertex(Vector3 pos, Vector3 normal, Vector2 uv) { }
        public virtual Vertex clone()
        {
            return new Vertex(this.pos.clone(), this.normal.clone(), this.uv.clone());
        }
        public virtual void flip()
        {
            this.normal = this.normal.scale(-1);
        }
        public virtual Vertex interpolate(object other, object t)
        {
            return new Vertex(Vector3.Lerp(this.pos, other.pos, t), Vector3.Lerp(this.normal, other.normal, t), Vector2.Lerp(this.uv, other.uv, t));
        }
    }
    public partial class Plane
    {
        public Vector3 normal;
        public double w;
        public Plane(Vector3 normal, double w) { }
        const int EPSILON = 1e-5;
        public static Plane FromPoints(Vector3 a, Vector3 b, Vector3 c)
        {
            var v0 = c.subtract(a);
            var v1 = b.subtract(a);
            if (v0.lengthSquared() == 0 || v1.lengthSquared() == 0)
            {
                return null;
            }
            var n = Vector3.Normalize(Vector3.Cross(v0, v1));
            return new Plane(n, Vector3.Dot(n, a));
        }
        public virtual Plane clone()
        {
            return new Plane(this.normal.clone(), this.w);
        }
        public virtual void flip()
        {
            this.normal.scaleInPlace(-1);
            this.w = -this.w;
        }
        public virtual void splitPolygon(Polygon polygon, Array<Polygon> coplanarFront, Array<Polygon> coplanarBack, Array<Polygon> front, Array<Polygon> back)
        {
            var COPLANAR = 0;
            var FRONT = 1;
            var BACK = 2;
            var SPANNING = 3;
            var polygonType = 0;
            var types = new Array<object>();
            for (var i = 0; i < polygon.vertices.Length; i++)
            {
                var t = Vector3.Dot(this.normal, polygon.vertices[i].pos) - this.w;
                var type = ((t < -Plane.EPSILON)) ? BACK : ((t > Plane.EPSILON)) ? FRONT : COPLANAR;
                polygonType |= type;
                types.Add(type);
            }
            switch (polygonType)
            {
                case COPLANAR:
                    ((Vector3.Dot(this.normal, polygon.plane.normal) > 0) ? coplanarFront : coplanarBack).Add(polygon);
                    break;
                case FRONT:
                    front.Add(polygon);
                    break;
                case BACK:
                    back.Add(polygon);
                    break;
                case SPANNING:
                    var f = new Array<object>();
                    var b = new Array<object>();
                    for (i = 0; i < polygon.vertices.Length; i++)
                    {
                        var j = (i + 1) % polygon.vertices.Length;
                        var ti = types[i];
                        var tj = types[j];
                        var vi = polygon.vertices[i];
                        var vj = polygon.vertices[j];
                        if (ti != BACK)
                            f.Add(vi);
                        if (ti != FRONT)
                            b.Add((ti != BACK) ? vi.clone() : vi);
                        if ((ti | tj) == SPANNING)
                        {
                            t = (this.w - Vector3.Dot(this.normal, vi.pos)) / Vector3.Dot(this.normal, vj.pos.subtract(vi.pos));
                            var v = vi.interpolate(vj, t);
                            f.Add(v);
                            b.Add(v.clone());
                        }
                    }
                    if (f.Length >= 3)
                    {
                        var poly = new Polygon(f, polygon.shared);
                        if (poly.plane)
                            front.Add(poly);
                    }
                    if (b.Length >= 3)
                    {
                        poly = new Polygon(b, polygon.shared);
                        if (poly.plane)
                            back.Add(poly);
                    }
                    break;
            }
        }
    }
    public partial class Polygon
    {
        public Array<Vertex> vertices;
        public dynamic shared;
        public Plane plane;
        public Polygon(Array<Vertex> vertices, object shared)
        {
            this.vertices = vertices;
            this.shared = shared;
            this.plane = Plane.FromPoints(vertices[0].pos, vertices[1].pos, vertices[2].pos);
        }
        public virtual Polygon clone()
        {
            var vertices = this.vertices.map((v) => v.clone());
            return new Polygon(vertices, this.shared);
        }
        public virtual void flip()
        {
            this.vertices.reverse().map((v) =>
            {
                v.flip();
            });
            this.plane.flip();
        }
    }
    public partial class Node
    {
        private any plane = null;
        private any front = null;
        private any back = null;
        private Array<object> polygons = new Array<object>();
        public Node(object polygons = null)
        {
            if (polygons)
            {
                this.build(polygons);
            }
        }
        public virtual Node clone()
        {
            var node = new Node();
            node.plane = this.plane && this.plane.clone();
            node.front = this.front && this.front.clone();
            node.back = this.back && this.back.clone();
            node.polygons = this.polygons.map((p) => p.clone());
            return node;
        }
        public virtual void invert()
        {
            for (var i = 0; i < this.polygons.Length; i++)
            {
                this.polygons[i].flip();
            }
            if (this.plane)
            {
                this.plane.flip();
            }
            if (this.front)
            {
                this.front.invert();
            }
            if (this.back)
            {
                this.back.invert();
            }
            var temp = this.front;
            this.front = this.back;
            this.back = temp;
        }
        public virtual void clipPolygons(Array<Polygon> polygons)
        {
            if (!this.plane)
                return polygons.slice();
            var front = new Array<object>();
            var back = new Array<object>();
            for (var i = 0; i < polygons.Length; i++)
            {
                this.plane.splitPolygon(polygons[i], front, back, front, back);
            }
            if (this.front)
            {
                front = this.front.clipPolygons(front);
            }
            if (this.back)
            {
                back = this.back.clipPolygons(back);
            }
            else
            {
                back = new Array<object>();
            }
            return front.concat(back);
        }
        public virtual void clipTo(Node bsp)
        {
            this.polygons = bsp.clipPolygons(this.polygons);
            if (this.front)
                this.front.clipTo(bsp);
            if (this.back)
                this.back.clipTo(bsp);
        }
        public virtual Array<Polygon> allPolygons()
        {
            var polygons = this.polygons.slice();
            if (this.front)
                polygons = polygons.concat(this.front.allPolygons());
            if (this.back)
                polygons = polygons.concat(this.back.allPolygons());
            return polygons;
        }
        public virtual void build(Array<Polygon> polygons)
        {
            if (!polygons.Length)
                return;
            if (!this.plane)
                this.plane = polygons[0].plane.clone();
            var front = new Array<object>();
            var back = new Array<object>();
            for (var i = 0; i < polygons.Length; i++)
            {
                this.plane.splitPolygon(polygons[i], this.polygons, this.polygons, front, back);
            }
            if (front.Length)
            {
                if (!this.front)
                    this.front = new Node();
                this.front.build(front);
            }
            if (back.Length)
            {
                if (!this.back)
                    this.back = new Node();
                this.back.build(back);
            }
        }
    }
    public partial class CSG
    {
        private Array<Polygon> polygons = new Array<Polygon>();
        public Matrix matrix;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scaling;
        public static void FromMesh(Mesh mesh) {
            var vertex;
            var normal;
            var uv;
            var position;
            var polygon;
            var polygons = new Array < object > ();
            var vertices;
            if (mesh is BABYLON.Mesh) {
                mesh.computeWorldMatrix(true);
                var matrix = mesh.getWorldMatrix();
                var meshPosition = mesh.position.clone();
                var meshRotation = mesh.rotation.clone();
                var meshScaling = mesh.scaling.clone();
            } else {
                throw "BABYLON.CSG: Wrong Mesh type, must be BABYLON.Mesh";
            }
            var indices = mesh.getIndices();
            var positions = mesh.getVerticesData(BABYLON.VertexBufferKind.PositionKind);
            var normals = mesh.getVerticesData(BABYLON.VertexBufferKind.NormalKind);
            var uvs = mesh.getVerticesData(BABYLON.VertexBufferKind.UVKind);
            var subMeshes = mesh.subMeshes;
            for (var sm = 0;
                var sml = subMeshes.Length; sm < sml; sm++) {
                for (var i = subMeshes[sm].indexStart;
                    var il = subMeshes[sm].indexCount + subMeshes[sm].indexStart; i < il; i += 3) {
                    vertices = new Array < object > ();
                    for (var j = 0; j < 3; j++) {
                        normal = new BABYLON.Vector3(normals[indices[i + j] * 3], normals[indices[i + j] * 3 + 1], normals[indices[i + j] * 3 + 2]);
                        uv = new BABYLON.Vector2(uvs[indices[i + j] * 2], uvs[indices[i + j] * 2 + 1]);
                        position = new BABYLON.Vector3(positions[indices[i + j] * 3], positions[indices[i + j] * 3 + 1], positions[indices[i + j] * 3 + 2]);
                        BABYLON.Vector3.TransformCoordinatesToRef(position, matrix, position);
                        BABYLON.Vector3.TransformNormalToRef(normal, matrix, normal);
                        vertex = new Vertex(position, normal, uv);
                        vertices.Add(vertex);
                    }
                    polygon = new Polygon(vertices, new {});
                    if (polygon.plane)
                        polygons.Add(polygon);
                }
            }
            var csg = CSG.FromPolygons(polygons);
            csg.matrix = matrix;
            csg.position = meshPosition;
            csg.rotation = meshRotation;
            csg.scaling = meshScaling;
            currentCSGMeshId++;
            return csg;
        }
        private static CSG FromPolygons(Array<Polygon> polygons)
        {
            var csg = new BABYLON.CSG();
            csg.polygons = polygons;
            return csg;
        }
        public virtual CSG clone()
        {
            var csg = new BABYLON.CSG();
            csg.polygons = this.polygons.map((p) => p.clone());
            csg.copyTransformAttributes(this);
            return csg;
        }
        private Array<Polygon> toPolygons()
        {
            return this.polygons;
        }
        public virtual CSG union(CSG csg)
        {
            var a = new Node(this.clone().polygons);
            var b = new Node(csg.clone().polygons);
            a.clipTo(b);
            b.clipTo(a);
            b.invert();
            b.clipTo(a);
            b.invert();
            a.build(b.allPolygons());
            return CSG.FromPolygons(a.allPolygons()).copyTransformAttributes(this);
        }
        public virtual void unionInPlace(CSG csg)
        {
            var a = new Node(this.polygons);
            var b = new Node(csg.polygons);
            a.clipTo(b);
            b.clipTo(a);
            b.invert();
            b.clipTo(a);
            b.invert();
            a.build(b.allPolygons());
            this.polygons = a.allPolygons();
        }
        public virtual CSG subtract(CSG csg)
        {
            var a = new Node(this.clone().polygons);
            var b = new Node(csg.clone().polygons);
            a.invert();
            a.clipTo(b);
            b.clipTo(a);
            b.invert();
            b.clipTo(a);
            b.invert();
            a.build(b.allPolygons());
            a.invert();
            return CSG.FromPolygons(a.allPolygons()).copyTransformAttributes(this);
        }
        public virtual void subtractInPlace(CSG csg)
        {
            var a = new Node(this.polygons);
            var b = new Node(csg.polygons);
            a.invert();
            a.clipTo(b);
            b.clipTo(a);
            b.invert();
            b.clipTo(a);
            b.invert();
            a.build(b.allPolygons());
            a.invert();
            this.polygons = a.allPolygons();
        }
        public virtual CSG intersect(CSG csg)
        {
            var a = new Node(this.clone().polygons);
            var b = new Node(csg.clone().polygons);
            a.invert();
            b.clipTo(a);
            b.invert();
            a.clipTo(b);
            b.clipTo(a);
            a.build(b.allPolygons());
            a.invert();
            return CSG.FromPolygons(a.allPolygons()).copyTransformAttributes(this);
        }
        public virtual void intersectInPlace(CSG csg)
        {
            var a = new Node(this.polygons);
            var b = new Node(csg.polygons);
            a.invert();
            b.clipTo(a);
            b.invert();
            a.clipTo(b);
            b.clipTo(a);
            a.build(b.allPolygons());
            a.invert();
            this.polygons = a.allPolygons();
        }
        public virtual CSG inverse()
        {
            var csg = this.clone();
            csg.inverseInPlace();
            return csg;
        }
        public virtual void inverseInPlace()
        {
            this.polygons.map((p) =>
            {
                p.flip();
            });
        }
        public virtual CSG copyTransformAttributes(CSG csg)
        {
            this.matrix = csg.matrix;
            this.position = csg.position;
            this.rotation = csg.rotation;
            this.scaling = csg.scaling;
            return this;
        }
        public virtual Mesh buildMeshGeometry(string name, Scene scene, bool keepSubMeshes) {
            var matrix = this.matrix.clone();
            matrix.invert();
            var mesh = new BABYLON.Mesh(name, scene);
            var vertices = new Array < object > ();
            var indices = new Array < object > ();
            var normals = new Array < object > ();
            var uvs = new Array < object > ();
            var vertex = BABYLON.Vector3.Zero();
            var normal = BABYLON.Vector3.Zero();
            var uv = BABYLON.Vector2.Zero();
            var polygons = this.polygons;
            var polygonIndices = new Array < object > (0, 0, 0);
            var polygon;
            var vertice_dict = new {};
            var vertex_idx;
            var currentIndex = 0;
            var subMesh_dict = new {};
            var subMesh_obj;
            if (keepSubMeshes) {
                polygons.sort((object a, object b) => {
                    if (a.shared.meshId == b.shared.meshId) {
                        return a.shared.subMeshId - b.shared.subMeshId;
                    } else {
                        return a.shared.meshId - b.shared.meshId;
                    }
                });
            }
            for (var i = 0;
                var il = polygons.Length; i < il; i++) {
                polygon = polygons[i];
                if (!subMesh_dict[polygon.shared.meshId]) {
                    subMesh_dict[polygon.shared.meshId] = new {};
                }
                if (!subMesh_dict[polygon.shared.meshId][polygon.shared.subMeshId]) {
                    subMesh_dict[polygon.shared.meshId][polygon.shared.subMeshId] = new {};
                }
                subMesh_obj = subMesh_dict[polygon.shared.meshId][polygon.shared.subMeshId];
                for (var j = 2;
                    var jl = polygon.vertices.Length; j < jl; j++) {
                    polygonIndices[0] = 0;
                    polygonIndices[1] = j - 1;
                    polygonIndices[2] = j;
                    for (var k = 0; k < 3; k++) {
                        vertex.copyFrom(polygon.vertices[polygonIndices[k]].pos);
                        normal.copyFrom(polygon.vertices[polygonIndices[k]].normal);
                        uv.copyFrom(polygon.vertices[polygonIndices[k]].uv);
                        BABYLON.Vector3.TransformCoordinatesToRef(vertex, matrix, vertex);
                        BABYLON.Vector3.TransformNormalToRef(normal, matrix, normal);
                        vertex_idx = vertice_dict[vertex.x + "," + vertex.y + "," + vertex.z];
                        if (!(typeof(vertex_idx) != "undefined" && normals[vertex_idx * 3] == normal.x && normals[vertex_idx * 3 + 1] == normal.y && normals[vertex_idx * 3 + 2] == normal.z && uvs[vertex_idx * 2] == uv.x && uvs[vertex_idx * 2 + 1] == uv.y)) {
                            vertices.Add(vertex.x, vertex.y, vertex.z);
                            uvs.Add(uv.x, uv.y);
                            normals.Add(normal.x, normal.y, normal.z);
                            vertex_idx = vertice_dict[vertex.x + "," + vertex.y + "," + vertex.z] = (vertices.Length / 3) - 1;
                        }
                        indices.Add(vertex_idx);
                        subMesh_obj.indexStart = Math.min(currentIndex, subMesh_obj.indexStart);
                        subMesh_obj.indexEnd = Math.Max(currentIndex, subMesh_obj.indexEnd);
                        currentIndex++;
                    }
                }
            }
            mesh.setVerticesData(BABYLON.VertexBufferKind.PositionKind, vertices);
            mesh.setVerticesData(BABYLON.VertexBufferKind.NormalKind, normals);
            mesh.setVerticesData(BABYLON.VertexBufferKind.UVKind, uvs);
            mesh.setIndices(indices);
            if (keepSubMeshes) {
                var materialIndexOffset = 0;
                var materialMaxIndex;
                mesh.subMeshes.Length = 0;
                foreach(var m in subMesh_dict) {
                    materialMaxIndex = -1;
                    foreach(var sm in subMesh_dict[m]) {
                        subMesh_obj = subMesh_dict[m][sm];
                        BABYLON.SubMesh.CreateFromIndices(subMesh_obj.materialIndex + materialIndexOffset, subMesh_obj.indexStart, subMesh_obj.indexEnd - subMesh_obj.indexStart + 1, mesh);
                        materialMaxIndex = Math.Max(subMesh_obj.materialIndex, materialMaxIndex);
                    }
                    materialIndexOffset += ++materialMaxIndex;
                }
            }
            return mesh;
        }
        public virtual Mesh toMesh(string name, Material material, Scene scene, bool keepSubMeshes)
        {
            var mesh = this.buildMeshGeometry(name, scene, keepSubMeshes);
            mesh.material = material;
            mesh.position.copyFrom(this.position);
            mesh.rotation.copyFrom(this.rotation);
            mesh.scaling.copyFrom(this.scaling);
            mesh.computeWorldMatrix(true);
            return mesh;
        }
    }
     */
}