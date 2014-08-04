using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial interface IGetSetVerticesData
    {
        bool isVerticesDataPresent(VertexBufferKind kind);
        Array<double> getVerticesData(VertexBufferKind kind);
        Array<int> getIndices();
        void setVerticesData(VertexBufferKind kind, Array<double> data, bool updatable = false);
        void updateVerticesData(VertexBufferKind kind, Array<double> data, bool updateExtends = false, bool makeItUnique = false);
        void setIndices(Array<int> indices);
    }
    public partial class VertexData
    {
        public Array<double> positions;
        public Array<double> normals;
        public Array<double> uvs;
        public Array<double> uv2s;
        public Array<double> colors;
        public Array<double> matricesIndices;
        public Array<double> matricesWeights;
        public Array<int> indices;
        public virtual void set(Array<double> data, VertexBufferKind kind)
        {
            switch (kind)
            {
                case BABYLON.VertexBufferKind.PositionKind:
                    this.positions = data;
                    break;
                case BABYLON.VertexBufferKind.NormalKind:
                    this.normals = data;
                    break;
                case BABYLON.VertexBufferKind.UVKind:
                    this.uvs = data;
                    break;
                case BABYLON.VertexBufferKind.UV2Kind:
                    this.uv2s = data;
                    break;
                case BABYLON.VertexBufferKind.ColorKind:
                    this.colors = data;
                    break;
                case BABYLON.VertexBufferKind.MatricesIndicesKind:
                    this.matricesIndices = data;
                    break;
                case BABYLON.VertexBufferKind.MatricesWeightsKind:
                    this.matricesWeights = data;
                    break;
            }
        }
        public virtual void applyToMesh(Mesh mesh, bool updatable = false)
        {
            this._applyTo(mesh, updatable);
        }
        public virtual void applyToGeometry(Geometry geometry, bool updatable = false)
        {
            this._applyTo(geometry, updatable);
        }
        public virtual void updateMesh(Mesh mesh, bool updateExtends = false, bool makeItUnique = false)
        {
            this._update(mesh);
        }
        public virtual void updateGeometry(Geometry geometry, bool updateExtends = false, bool makeItUnique = false)
        {
            this._update(geometry);
        }
        private void _applyTo(IGetSetVerticesData meshOrGeometry, bool updatable = false)
        {
            if (this.positions != null)
            {
                meshOrGeometry.setVerticesData(BABYLON.VertexBufferKind.PositionKind, this.positions, updatable);
            }
            if (this.normals != null)
            {
                meshOrGeometry.setVerticesData(BABYLON.VertexBufferKind.NormalKind, this.normals, updatable);
            }
            if (this.uvs != null)
            {
                meshOrGeometry.setVerticesData(BABYLON.VertexBufferKind.UVKind, this.uvs, updatable);
            }
            if (this.uv2s != null)
            {
                meshOrGeometry.setVerticesData(BABYLON.VertexBufferKind.UV2Kind, this.uv2s, updatable);
            }
            if (this.colors != null)
            {
                meshOrGeometry.setVerticesData(BABYLON.VertexBufferKind.ColorKind, this.colors, updatable);
            }
            if (this.matricesIndices != null)
            {
                meshOrGeometry.setVerticesData(BABYLON.VertexBufferKind.MatricesIndicesKind, this.matricesIndices, updatable);
            }
            if (this.matricesWeights != null)
            {
                meshOrGeometry.setVerticesData(BABYLON.VertexBufferKind.MatricesWeightsKind, this.matricesWeights, updatable);
            }
            if (this.indices != null)
            {
                meshOrGeometry.setIndices(this.indices);
            }
        }
        private void _update(IGetSetVerticesData meshOrGeometry, bool updateExtends = false, bool makeItUnique = false)
        {
            if (this.positions != null)
            {
                meshOrGeometry.updateVerticesData(BABYLON.VertexBufferKind.PositionKind, this.positions, updateExtends, makeItUnique);
            }
            if (this.normals != null)
            {
                meshOrGeometry.updateVerticesData(BABYLON.VertexBufferKind.NormalKind, this.normals, updateExtends, makeItUnique);
            }
            if (this.uvs != null)
            {
                meshOrGeometry.updateVerticesData(BABYLON.VertexBufferKind.UVKind, this.uvs, updateExtends, makeItUnique);
            }
            if (this.uv2s != null)
            {
                meshOrGeometry.updateVerticesData(BABYLON.VertexBufferKind.UV2Kind, this.uv2s, updateExtends, makeItUnique);
            }
            if (this.colors != null)
            {
                meshOrGeometry.updateVerticesData(BABYLON.VertexBufferKind.ColorKind, this.colors, updateExtends, makeItUnique);
            }
            if (this.matricesIndices != null)
            {
                meshOrGeometry.updateVerticesData(BABYLON.VertexBufferKind.MatricesIndicesKind, this.matricesIndices, updateExtends, makeItUnique);
            }
            if (this.matricesWeights != null)
            {
                meshOrGeometry.updateVerticesData(BABYLON.VertexBufferKind.MatricesWeightsKind, this.matricesWeights, updateExtends, makeItUnique);
            }
            if (this.indices != null)
            {
                meshOrGeometry.setIndices(this.indices);
            }
        }
        public virtual void transform(Matrix matrix)
        {
            var transformed = BABYLON.Vector3.Zero();
            if (this.positions != null)
            {
                var position = BABYLON.Vector3.Zero();
                for (var index = 0; index < this.positions.Length; index += 3)
                {
                    BABYLON.Vector3.FromArrayToRef(this.positions, index, position);
                    BABYLON.Vector3.TransformCoordinatesToRef(position, matrix, transformed);
                    this.positions[index] = transformed.x;
                    this.positions[index + 1] = transformed.y;
                    this.positions[index + 2] = transformed.z;
                }
            }
            if (this.normals != null)
            {
                var normal = BABYLON.Vector3.Zero();
                for (var index = 0; index < this.normals.Length; index += 3)
                {
                    BABYLON.Vector3.FromArrayToRef(this.normals, index, normal);
                    BABYLON.Vector3.TransformNormalToRef(normal, matrix, transformed);
                    this.normals[index] = transformed.x;
                    this.normals[index + 1] = transformed.y;
                    this.normals[index + 2] = transformed.z;
                }
            }
        }
        public virtual void merge(VertexData other)
        {
            if (other.indices != null)
            {
                if (this.indices == null)
                {
                    this.indices = new Array<int>();
                }
                var offset = (this.positions != null) ? this.positions.Length / 3 : 0;
                for (var index = 0; index < other.indices.Length; index++)
                {
                    this.indices.push(other.indices[index] + offset);
                }
            }
            if (other.positions != null)
            {
                if (this.positions == null)
                {
                    this.positions = new Array<double>();
                }
                for (var index = 0; index < other.positions.Length; index++)
                {
                    this.positions.push(other.positions[index]);
                }
            }
            if (other.normals != null)
            {
                if (this.normals == null)
                {
                    this.normals = new Array<double>();
                }
                for (var index = 0; index < other.normals.Length; index++)
                {
                    this.normals.push(other.normals[index]);
                }
            }
            if (other.uvs != null)
            {
                if (this.uvs == null)
                {
                    this.uvs = new Array<double>();
                }
                for (var index = 0; index < other.uvs.Length; index++)
                {
                    this.uvs.push(other.uvs[index]);
                }
            }
            if (other.uv2s != null)
            {
                if (this.uv2s == null)
                {
                    this.uv2s = new Array<double>();
                }
                for (var index = 0; index < other.uv2s.Length; index++)
                {
                    this.uv2s.push(other.uv2s[index]);
                }
            }
            if (other.matricesIndices != null)
            {
                if (this.matricesIndices == null)
                {
                    this.matricesIndices = new Array<double>();
                }
                for (var index = 0; index < other.matricesIndices.Length; index++)
                {
                    this.matricesIndices.push(other.matricesIndices[index]);
                }
            }
            if (other.matricesWeights != null)
            {
                if (this.matricesWeights == null)
                {
                    this.matricesWeights = new Array<double>();
                }
                for (var index = 0; index < other.matricesWeights.Length; index++)
                {
                    this.matricesWeights.push(other.matricesWeights[index]);
                }
            }
            if (other.colors != null)
            {
                if (this.colors == null)
                {
                    this.colors = new Array<double>();
                }
                for (var index = 0; index < other.colors.Length; index++)
                {
                    this.colors.push(other.colors[index]);
                }
            }
        }
        public static VertexData ExtractFromMesh(Mesh mesh)
        {
            return VertexData._ExtractFrom(mesh);
        }
        public static VertexData ExtractFromGeometry(Geometry geometry)
        {
            return VertexData._ExtractFrom(geometry);
        }
        private static VertexData _ExtractFrom(IGetSetVerticesData meshOrGeometry)
        {
            var result = new BABYLON.VertexData();
            if (meshOrGeometry.isVerticesDataPresent(BABYLON.VertexBufferKind.PositionKind))
            {
                result.positions = meshOrGeometry.getVerticesData(BABYLON.VertexBufferKind.PositionKind);
            }
            if (meshOrGeometry.isVerticesDataPresent(BABYLON.VertexBufferKind.NormalKind))
            {
                result.normals = meshOrGeometry.getVerticesData(BABYLON.VertexBufferKind.NormalKind);
            }
            if (meshOrGeometry.isVerticesDataPresent(BABYLON.VertexBufferKind.UVKind))
            {
                result.uvs = meshOrGeometry.getVerticesData(BABYLON.VertexBufferKind.UVKind);
            }
            if (meshOrGeometry.isVerticesDataPresent(BABYLON.VertexBufferKind.UV2Kind))
            {
                result.uv2s = meshOrGeometry.getVerticesData(BABYLON.VertexBufferKind.UV2Kind);
            }
            if (meshOrGeometry.isVerticesDataPresent(BABYLON.VertexBufferKind.ColorKind))
            {
                result.colors = meshOrGeometry.getVerticesData(BABYLON.VertexBufferKind.ColorKind);
            }
            if (meshOrGeometry.isVerticesDataPresent(BABYLON.VertexBufferKind.MatricesIndicesKind))
            {
                result.matricesIndices = meshOrGeometry.getVerticesData(BABYLON.VertexBufferKind.MatricesIndicesKind);
            }
            if (meshOrGeometry.isVerticesDataPresent(BABYLON.VertexBufferKind.MatricesWeightsKind))
            {
                result.matricesWeights = meshOrGeometry.getVerticesData(BABYLON.VertexBufferKind.MatricesWeightsKind);
            }
            result.indices = meshOrGeometry.getIndices();
            return result;
        }
        public static VertexData CreateBox(double size = 1.0)
        {
            var normalsSource = new Array<Vector3>(new BABYLON.Vector3(0, 0, 1), new BABYLON.Vector3(0, 0, -1), new BABYLON.Vector3(1, 0, 0), new BABYLON.Vector3(-1, 0, 0), new BABYLON.Vector3(0, 1, 0), new BABYLON.Vector3(0, -1, 0));
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            for (var index = 0; index < normalsSource.Length; index++)
            {
                var normal = normalsSource[index];
                var side1 = new BABYLON.Vector3(normal.y, normal.z, normal.x);
                var side2 = BABYLON.Vector3.Cross(normal, side1);
                var verticesLength = positions.Length / 3;
                indices.push(verticesLength);
                indices.push(verticesLength + 1);
                indices.push(verticesLength + 2);
                indices.push(verticesLength);
                indices.push(verticesLength + 2);
                indices.push(verticesLength + 3);
                var vertex = normal.subtract(side1).subtract(side2).scale(size / 2);
                positions.push(vertex.x, vertex.y, vertex.z);
                normals.push(normal.x, normal.y, normal.z);
                uvs.push(1.0, 1.0);
                vertex = normal.subtract(side1).add(side2).scale(size / 2);
                positions.push(vertex.x, vertex.y, vertex.z);
                normals.push(normal.x, normal.y, normal.z);
                uvs.push(0.0, 1.0);
                vertex = normal.add(side1).add(side2).scale(size / 2);
                positions.push(vertex.x, vertex.y, vertex.z);
                normals.push(normal.x, normal.y, normal.z);
                uvs.push(0.0, 0.0);
                vertex = normal.add(side1).subtract(side2).scale(size / 2);
                positions.push(vertex.x, vertex.y, vertex.z);
                normals.push(normal.x, normal.y, normal.z);
                uvs.push(1.0, 0.0);
            }
            var vertexData = new BABYLON.VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }
        public static VertexData CreateSphere(int segments = 32, double diameter = 1.0)
        {
            var radius = diameter / 2.0;
            var totalZRotationSteps = 2 + segments;
            var totalYRotationSteps = 2 * totalZRotationSteps;
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            for (var zRotationStep = 0; zRotationStep <= totalZRotationSteps; zRotationStep++)
            {
                var normalizedZ = (double)zRotationStep / (double)totalZRotationSteps;
                var angleZ = (normalizedZ * Math.PI);
                for (var yRotationStep = 0; yRotationStep <= totalYRotationSteps; yRotationStep++)
                {
                    var normalizedY = (double)yRotationStep / (double)totalYRotationSteps;
                    var angleY = normalizedY * Math.PI * 2.0;
                    var rotationZ = BABYLON.Matrix.RotationZ(-angleZ);
                    var rotationY = BABYLON.Matrix.RotationY(angleY);
                    var afterRotZ = BABYLON.Vector3.TransformCoordinates(BABYLON.Vector3.Up(), rotationZ);
                    var complete = BABYLON.Vector3.TransformCoordinates(afterRotZ, rotationY);
                    var vertex = complete.scale(radius);
                    var normal = BABYLON.Vector3.Normalize(vertex);
                    positions.push(vertex.x, vertex.y, vertex.z);
                    normals.push(normal.x, normal.y, normal.z);
                    uvs.push(normalizedZ, normalizedY);
                }
                if (zRotationStep > 0)
                {
                    var verticesCount = positions.Length / 3;
                    for (var firstIndex = verticesCount - 2 * (totalYRotationSteps + 1);
                        (firstIndex + totalYRotationSteps + 2) < verticesCount; firstIndex++)
                    {
                        indices.push(firstIndex);
                        indices.push(firstIndex + 1);
                        indices.push(firstIndex + totalYRotationSteps + 1);
                        indices.push(firstIndex + totalYRotationSteps + 1);
                        indices.push(firstIndex + 1);
                        indices.push(firstIndex + totalYRotationSteps + 2);
                    }
                }
            }
            var vertexData = new BABYLON.VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }
        public static VertexData CreateCylinder(double height = 1.0, double diameterTop = 0.5, double diameterBottom = 1.0, int tessellation = 16, int subdivisions = 1)
        {
            var radiusTop = diameterTop / 2;
            var radiusBottom = diameterBottom / 2;
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            subdivisions = ((subdivisions < 1)) ? 1 : subdivisions;
            var getCircleVector = new Func<int, Vector3>((i) =>
            {
                var angle = (i * 2.0 * Math.PI / tessellation);
                var dx = Math.Cos(angle);
                var dz = Math.Sin(angle);
                return new BABYLON.Vector3(dx, 0, dz);
            });
            Vector3 offset;
            var createCylinderCap = new Action<bool>((isTop) =>
                {
                    var radius = (isTop) ? radiusTop : radiusBottom;
                    if (radius == 0.0)
                    {
                        return;
                    }
                    var vbase = positions.Length / 3;
                    offset = new BABYLON.Vector3(0, height / 2, 0);
                    var textureScale = new BABYLON.Vector2(0.5, 0.5);
                    if (!isTop)
                    {
                        offset.scaleInPlace(-1.0);
                        textureScale.x = -textureScale.x;
                    }
                    for (var i = 0; i < tessellation; i++)
                    {
                        var circleVector = getCircleVector(i);
                        var position = circleVector.scale(radius).add(offset);
                        var textureCoordinate = new BABYLON.Vector2(circleVector.x * textureScale.x + 0.5, circleVector.z * textureScale.y + 0.5);
                        positions.push(position.x, position.y, position.z);
                        uvs.push(textureCoordinate.x, textureCoordinate.y);
                    }
                    for (var i = 0; i < tessellation - 2; i++)
                    {
                        if (!isTop)
                        {
                            indices.push(vbase);
                            indices.push(vbase + (i + 2) % tessellation);
                            indices.push(vbase + (i + 1) % tessellation);
                        }
                        else
                        {
                            indices.push(vbase);
                            indices.push(vbase + (i + 1) % tessellation);
                            indices.push(vbase + (i + 2) % tessellation);
                        }
                    }
                });
            var _base = new BABYLON.Vector3(0, -1, 0).scale(height / 2);
            offset = new BABYLON.Vector3(0, 1, 0).scale(height / subdivisions);
            var stride = tessellation + 1;
            for (var i = 0; i <= tessellation; i++)
            {
                var circleVector = getCircleVector(i);
                var textureCoordinate = new BABYLON.Vector2(i / tessellation, 0);
                var radius = radiusBottom;
                for (var s = 0; s <= subdivisions; s++)
                {
                    var position = circleVector.scale(radius);
                    position.addInPlace(_base.add(offset.scale(s)));
                    textureCoordinate.y += 1 / subdivisions;
                    radius += (radiusTop - radiusBottom) / subdivisions;
                    positions.push(position.x, position.y, position.z);
                    uvs.push(textureCoordinate.x, textureCoordinate.y);
                }
            }
            subdivisions += 1;
            for (var s = 0; s < subdivisions - 1; s++)
            {
                for (var i = 0; i <= tessellation; i++)
                {
                    indices.push(i * subdivisions + s);
                    indices.push((i * subdivisions + (s + subdivisions)) % (stride * subdivisions));
                    indices.push(i * subdivisions + (s + 1));
                    indices.push(i * subdivisions + (s + 1));
                    indices.push((i * subdivisions + (s + subdivisions)) % (stride * subdivisions));
                    indices.push((i * subdivisions + (s + subdivisions + 1)) % (stride * subdivisions));
                }
            }
            createCylinderCap(true);
            createCylinderCap(false);
            BABYLON.VertexData.ComputeNormals(positions, indices, normals);
            var vertexData = new BABYLON.VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }
        public static VertexData CreateTorus(double diameter = 1.0, double thickness = 0.5, int tessellation = 16)
        {
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            var stride = tessellation + 1;
            for (var i = 0; i <= tessellation; i++)
            {
                var u = i / tessellation;
                var outerAngle = i * Math.PI * 2.0 / tessellation - Math.PI / 2.0;
                var transform = BABYLON.Matrix.Translation(diameter / 2.0, 0, 0).multiply(BABYLON.Matrix.RotationY(outerAngle));
                for (var j = 0; j <= tessellation; j++)
                {
                    var v = 1 - j / tessellation;
                    var innerAngle = j * Math.PI * 2.0 / tessellation + Math.PI;
                    var dx = Math.Cos(innerAngle);
                    var dy = Math.Sin(innerAngle);
                    var normal = new BABYLON.Vector3(dx, dy, 0);
                    var position = normal.scale(thickness / 2);
                    var textureCoordinate = new BABYLON.Vector2(u, v);
                    position = BABYLON.Vector3.TransformCoordinates(position, transform);
                    normal = BABYLON.Vector3.TransformNormal(normal, transform);
                    positions.push(position.x, position.y, position.z);
                    normals.push(normal.x, normal.y, normal.z);
                    uvs.push(textureCoordinate.x, textureCoordinate.y);
                    var nextI = (i + 1) % stride;
                    var nextJ = (j + 1) % stride;
                    indices.push(i * stride + j);
                    indices.push(i * stride + nextJ);
                    indices.push(nextI * stride + j);
                    indices.push(i * stride + nextJ);
                    indices.push(nextI * stride + nextJ);
                    indices.push(nextI * stride + j);
                }
            }
            var vertexData = new BABYLON.VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }
        public static VertexData CreateLines(Array<Vector3> points)
        {
            var indices = new Array<int>();
            var positions = new Array<double>();
            for (var index = 0; index < points.Length; index++)
            {
                positions.push(points[index].x, points[index].y, points[index].z);
                if (index > 0)
                {
                    indices.push(index - 1);
                    indices.push(index);
                }
            }
            var vertexData = new BABYLON.VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            return vertexData;
        }
        public static VertexData CreateGround(double width = 1.0, double height = 1.0, int subdivisions = 1)
        {
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            for (var row = 0; row <= subdivisions; row++)
            {
                for (var col = 0; col <= subdivisions; col++)
                {
                    var position = new BABYLON.Vector3((col * width) / subdivisions - (width / 2.0), 0, ((subdivisions - row) * height) / subdivisions - (height / 2.0));
                    var normal = new BABYLON.Vector3(0, 1.0, 0);
                    positions.push(position.x, position.y, position.z);
                    normals.push(normal.x, normal.y, normal.z);
                    uvs.push(col / subdivisions, 1.0 - row / subdivisions);
                }
            }
            for (var row = 0; row < subdivisions; row++)
            {
                for (var col = 0; col < subdivisions; col++)
                {
                    indices.push(col + 1 + (row + 1) * (subdivisions + 1));
                    indices.push(col + 1 + row * (subdivisions + 1));
                    indices.push(col + row * (subdivisions + 1));
                    indices.push(col + (row + 1) * (subdivisions + 1));
                    indices.push(col + 1 + (row + 1) * (subdivisions + 1));
                    indices.push(col + row * (subdivisions + 1));
                }
            }
            var vertexData = new BABYLON.VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }
        public static VertexData CreateTiledGround(double xmin, double zmin, double xmax, double zmax, SizeI subdivisions, SizeI precision)
        {
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            subdivisions.h = ((subdivisions.w < 1)) ? 1 : subdivisions.h;
            subdivisions.w = ((subdivisions.w < 1)) ? 1 : subdivisions.w;
            precision.w = ((precision.w < 1)) ? 1 : precision.w;
            precision.h = ((precision.h < 1)) ? 1 : precision.h;
            var tileSize = new SizeI
                               {
                                   w = (int)((xmax - xmin) / subdivisions.w),
                                   h = (int)((zmax - zmin) / subdivisions.h)
                               };
            for (var tileRow = 0; tileRow < subdivisions.h; tileRow++)
            {
                for (var tileCol = 0; tileCol < subdivisions.w; tileCol++)
                {
                    var xTileMin = xmin + tileCol * tileSize.w;
                    var zTileMin = zmin + tileRow * tileSize.h;
                    var xTileMax = xmin + (tileCol + 1) * tileSize.w;
                    var zTileMax = zmin + (tileRow + 1) * tileSize.h;

                    // Indices
                    var _base = positions.Length / 3;
                    var rowLength = precision.w + 1;
                    for (var row = 0; row < precision.h; row++)
                    {
                        for (var col = 0; col < precision.w; col++)
                        {
                            var square = new Array<int>(
                                _base + col + row * rowLength,
                                _base + (col + 1) + row * rowLength,
                                _base + (col + 1) + (row + 1) * rowLength,
                                _base + col + (row + 1) * rowLength
                            );

                            indices.push(square[1]);
                            indices.push(square[2]);
                            indices.push(square[3]);
                            indices.push(square[0]);
                            indices.push(square[1]);
                            indices.push(square[3]);
                        }
                    }

                    // Position, normals and uvs
                    var position = BABYLON.Vector3.Zero();
                    var normal = new BABYLON.Vector3(0, 1.0, 0);
                    for (var row = 0; row <= precision.h; row++)
                    {
                        position.z = (row * (zTileMax - zTileMin)) / precision.h + zTileMin;
                        for (var col = 0; col <= precision.w; col++)
                        {
                            position.x = (col * (xTileMax - xTileMin)) / precision.w + xTileMin;
                            position.y = 0;

                            positions.push(position.x, position.y, position.z);
                            normals.push(normal.x, normal.y, normal.z);
                            uvs.push(col / precision.w, row / precision.h);
                        }
                    }

                }
            }
            var vertexData = new BABYLON.VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }

        public static VertexData CreateGroundFromHeightMap(double width, double height, int subdivisions, double minHeight, double maxHeight, Web.Uint8Array buffer, double bufferWidth, double bufferHeight)
        {
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            for (var row = 0; row <= subdivisions; row++)
            {
                for (var col = 0; col <= subdivisions; col++)
                {
                    var position = new BABYLON.Vector3((col * width) / subdivisions - (width / 2.0), 0, ((subdivisions - row) * height) / subdivisions - (height / 2.0));
                    var heightMapX = (((position.x + width / 2) / width) * (bufferWidth - 1));
                    var heightMapY = ((1.0 - (position.z + height / 2) / height) * (bufferHeight - 1));
                    var pos = (int)(heightMapX + heightMapY * bufferWidth) * 4;
                    var r = buffer[pos] / 255.0;
                    var g = buffer[pos + 1] / 255.0;
                    var b = buffer[pos + 2] / 255.0;
                    var gradient = r * 0.3 + g * 0.59 + b * 0.11;
                    position.y = minHeight + (maxHeight - minHeight) * gradient;
                    positions.push(position.x, position.y, position.z);
                    normals.push(0, 0, 0);
                    uvs.push(col / subdivisions, 1.0 - row / subdivisions);
                }
            }
            for (var row = 0; row < subdivisions; row++)
            {
                for (var col = 0; col < subdivisions; col++)
                {
                    indices.push(col + 1 + (row + 1) * (subdivisions + 1));
                    indices.push(col + 1 + row * (subdivisions + 1));
                    indices.push(col + row * (subdivisions + 1));
                    indices.push(col + (row + 1) * (subdivisions + 1));
                    indices.push(col + 1 + (row + 1) * (subdivisions + 1));
                    indices.push(col + row * (subdivisions + 1));
                }
            }
            BABYLON.VertexData.ComputeNormals(positions, indices, normals);
            var vertexData = new BABYLON.VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }
        public static VertexData CreatePlane(double size = 1)
        {
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            var halfSize = size / 2.0;
            positions.push(-halfSize, -halfSize, 0);
            normals.push(0, 0, -1.0);
            uvs.push(0.0, 0.0);
            positions.push(halfSize, -halfSize, 0);
            normals.push(0, 0, -1.0);
            uvs.push(1.0, 0.0);
            positions.push(halfSize, halfSize, 0);
            normals.push(0, 0, -1.0);
            uvs.push(1.0, 1.0);
            positions.push(-halfSize, halfSize, 0);
            normals.push(0, 0, -1.0);
            uvs.push(0.0, 1.0);
            indices.push(0);
            indices.push(1);
            indices.push(2);
            indices.push(0);
            indices.push(2);
            indices.push(3);
            var vertexData = new BABYLON.VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }
        public static VertexData CreateTorusKnot(double radius = 2, double tube = 0.5, int radialSegments = 32, int tubularSegments = 32, double p = 2, double q = 3)
        {
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            var getPos = new Func<double, Vector3>(angle =>
                {
                    var cu = Math.Cos(angle);
                    var su = Math.Sin(angle);
                    var quOverP = q / p * angle;
                    var cs = Math.Cos(quOverP);
                    var tx = radius * (2 + cs) * 0.5 * cu;
                    var ty = radius * (2 + cs) * su * 0.5;
                    var tz = radius * Math.Sin(quOverP) * 0.5;
                    return new BABYLON.Vector3(tx, ty, tz);
                });
            for (var i = 0; i <= radialSegments; i++)
            {
                var modI = i % radialSegments;
                var u = modI / radialSegments * 2 * p * Math.PI;
                var p1 = getPos(u);
                var p2 = getPos(u + 0.01);
                var tang = p2.subtract(p1);
                var n = p2.add(p1);
                var bitan = BABYLON.Vector3.Cross(tang, n);
                n = BABYLON.Vector3.Cross(bitan, tang);
                bitan.normalize();
                n.normalize();
                for (var j = 0; j < tubularSegments; j++)
                {
                    var modJ = j % tubularSegments;
                    var v = modJ / tubularSegments * 2 * Math.PI;
                    var cx = -tube * Math.Cos(v);
                    var cy = tube * Math.Sin(v);
                    positions.push(p1.x + cx * n.x + cy * bitan.x);
                    positions.push(p1.y + cx * n.y + cy * bitan.y);
                    positions.push(p1.z + cx * n.z + cy * bitan.z);
                    uvs.push(i / radialSegments);
                    uvs.push(j / tubularSegments);
                }
            }
            for (var i = 0; i < radialSegments; i++)
            {
                for (var j = 0; j < tubularSegments; j++)
                {
                    var jNext = (j + 1) % tubularSegments;
                    var a = i * tubularSegments + j;
                    var b = (i + 1) * tubularSegments + j;
                    var c = (i + 1) * tubularSegments + jNext;
                    var d = i * tubularSegments + jNext;
                    indices.push(d);
                    indices.push(b);
                    indices.push(a);
                    indices.push(d);
                    indices.push(c);
                    indices.push(b);
                }
            }
            BABYLON.VertexData.ComputeNormals(positions, indices, normals);
            var vertexData = new BABYLON.VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }
        public static void ComputeNormals(Array<double> positions, Array<int> indices, Array<double> normals)
        {
            var positionVectors = new Array<Vector3>();
            var facesOfVertices = new Array<Array<int>>();
            for (var index = 0; index < positions.Length; index += 3)
            {
                var vector3 = new BABYLON.Vector3(positions[index], positions[index + 1], positions[index + 2]);
                positionVectors.push(vector3);
                facesOfVertices.push(new Array<int>());
            }
            var facesNormals = new Array<Vector3>();
            for (var index = 0; index < indices.Length / 3; index++)
            {
                var i1 = indices[index * 3];
                var i2 = indices[index * 3 + 1];
                var i3 = indices[index * 3 + 2];
                var p1 = positionVectors[i1];
                var p2 = positionVectors[i2];
                var p3 = positionVectors[i3];
                var p1p2 = p1.subtract(p2);
                var p3p2 = p3.subtract(p2);
                facesNormals[index] = BABYLON.Vector3.Normalize(BABYLON.Vector3.Cross(p1p2, p3p2));
                facesOfVertices[i1].push(index);
                facesOfVertices[i2].push(index);
                facesOfVertices[i3].push(index);
            }
            for (var index = 0; index < positionVectors.Length; index++)
            {
                var faces = facesOfVertices[index];
                var normal = BABYLON.Vector3.Zero();
                for (var faceIndex = 0; faceIndex < faces.Length; faceIndex++)
                {
                    normal.addInPlace(facesNormals[faces[faceIndex]]);
                }
                normal = BABYLON.Vector3.Normalize(normal.scale(1.0 / faces.Length));
                normals[index * 3] = normal.x;
                normals[index * 3 + 1] = normal.y;
                normals[index * 3 + 2] = normal.z;
            }
        }
    }
}