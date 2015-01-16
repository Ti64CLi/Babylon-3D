// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.mesh.vertexData.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    using Web;

    /// <summary>
    /// </summary>
    public partial interface IGetSetVerticesData
    {
        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        Array<int> getIndices();

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <returns>
        /// </returns>
        Array<double> getVerticesData(VertexBufferKind kind);

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <returns>
        /// </returns>
        bool isVerticesDataPresent(VertexBufferKind kind);

        /// <summary>
        /// </summary>
        /// <param name="indices">
        /// </param>
        void setIndices(Array<int> indices);

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <param name="data">
        /// </param>
        /// <param name="updatable">
        /// </param>
        void setVerticesData(VertexBufferKind kind, Array<double> data, bool updatable = false);

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <param name="data">
        /// </param>
        /// <param name="updateExtends">
        /// </param>
        /// <param name="makeItUnique">
        /// </param>
        void updateVerticesData(VertexBufferKind kind, Array<double> data, bool updateExtends = false, bool makeItUnique = false);
    }

    /// <summary>
    /// </summary>
    public partial class VertexData
    {
        /// <summary>
        /// </summary>
        public Array<double> colors;

        /// <summary>
        /// </summary>
        public Array<int> indices;

        /// <summary>
        /// </summary>
        public Array<double> matricesIndices;

        /// <summary>
        /// </summary>
        public Array<double> matricesWeights;

        /// <summary>
        /// </summary>
        public Array<double> normals;

        /// <summary>
        /// </summary>
        public Array<double> positions;

        /// <summary>
        /// </summary>
        public Array<double> uv2s;

        /// <summary>
        /// </summary>
        public Array<double> uvs;

        /// <summary>
        /// </summary>
        /// <param name="positions">
        /// </param>
        /// <param name="indices">
        /// </param>
        /// <param name="normals">
        /// </param>
        public static void ComputeNormals(Array<double> positions, Array<int> indices, Array<double> normals)
        {
            var positionVectors = new Array<Vector3>();
            var facesOfVertices = new Array<Array<int>>();
            for (var index = 0; index < positions.Length; index += 3)
            {
                var vector3 = new Vector3(positions[index], positions[index + 1], positions[index + 2]);
                positionVectors.Add(vector3);
                facesOfVertices.Add(new Array<int>());
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
                facesNormals[index] = Vector3.Normalize(Vector3.Cross(p1p2, p3p2));
                facesOfVertices[i1].Add(index);
                facesOfVertices[i2].Add(index);
                facesOfVertices[i3].Add(index);
            }

            for (var index = 0; index < positionVectors.Length; index++)
            {
                var faces = facesOfVertices[index];
                var normal = Vector3.Zero();
                for (var faceIndex = 0; faceIndex < faces.Length; faceIndex++)
                {
                    normal.addInPlace(facesNormals[faces[faceIndex]]);
                }

                normal = Vector3.Normalize(normal.scale(1.0 / faces.Length));
                normals[index * 3] = normal.x;
                normals[index * 3 + 1] = normal.y;
                normals[index * 3 + 2] = normal.z;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="size">
        /// </param>
        /// <returns>
        /// </returns>
        public static VertexData CreateBox(double size = 1.0)
        {
            var normalsSource = new Array<Vector3>(
                new Vector3(0, 0, 1), new Vector3(0, 0, -1), new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, -1, 0));
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            for (var index = 0; index < normalsSource.Length; index++)
            {
                var normal = normalsSource[index];
                var side1 = new Vector3(normal.y, normal.z, normal.x);
                var side2 = Vector3.Cross(normal, side1);
                var verticesLength = positions.Length / 3;
                indices.Add(verticesLength);
                indices.Add(verticesLength + 1);
                indices.Add(verticesLength + 2);
                indices.Add(verticesLength);
                indices.Add(verticesLength + 2);
                indices.Add(verticesLength + 3);
                var vertex = normal.subtract(side1).subtract(side2).scale(size / 2);
                positions.Add(vertex.x, vertex.y, vertex.z);
                normals.Add(normal.x, normal.y, normal.z);
                uvs.Add(1.0, 1.0);
                vertex = normal.subtract(side1).add(side2).scale(size / 2);
                positions.Add(vertex.x, vertex.y, vertex.z);
                normals.Add(normal.x, normal.y, normal.z);
                uvs.Add(0.0, 1.0);
                vertex = normal.add(side1).add(side2).scale(size / 2);
                positions.Add(vertex.x, vertex.y, vertex.z);
                normals.Add(normal.x, normal.y, normal.z);
                uvs.Add(0.0, 0.0);
                vertex = normal.add(side1).subtract(side2).scale(size / 2);
                positions.Add(vertex.x, vertex.y, vertex.z);
                normals.Add(normal.x, normal.y, normal.z);
                uvs.Add(1.0, 0.0);
            }

            var vertexData = new VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }

        /// <summary>
        /// </summary>
        /// <param name="height">
        /// </param>
        /// <param name="diameterTop">
        /// </param>
        /// <param name="diameterBottom">
        /// </param>
        /// <param name="tessellation">
        /// </param>
        /// <param name="subdivisions">
        /// </param>
        /// <returns>
        /// </returns>
        public static VertexData CreateCylinder(
            double height = 1.0, double diameterTop = 0.5, double diameterBottom = 1.0, int tessellation = 16, int subdivisions = 1)
        {
            var radiusTop = diameterTop / 2;
            var radiusBottom = diameterBottom / 2;
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            subdivisions = (subdivisions < 1) ? 1 : subdivisions;
            var getCircleVector = new Func<int, Vector3>(
                (i) =>
                {
                    var angle = i * 2.0 * Math.PI / tessellation;
                    var dx = Math.Cos(angle);
                    var dz = Math.Sin(angle);
                    return new Vector3(dx, 0, dz);
                });
            Vector3 offset;
            var createCylinderCap = new Action<bool>(
                (isTop) =>
                {
                    var radius = isTop ? radiusTop : radiusBottom;
                    if (radius == 0.0)
                    {
                        return;
                    }

                    var vbase = positions.Length / 3;
                    offset = new Vector3(0, height / 2, 0);
                    var textureScale = new Vector2(0.5, 0.5);
                    if (!isTop)
                    {
                        offset.scaleInPlace(-1.0);
                        textureScale.x = -textureScale.x;
                    }

                    for (var i = 0; i < tessellation; i++)
                    {
                        var circleVector = getCircleVector(i);
                        var position = circleVector.scale(radius).add(offset);
                        var textureCoordinate = new Vector2(circleVector.x * textureScale.x + 0.5, circleVector.z * textureScale.y + 0.5);
                        positions.Add(position.x, position.y, position.z);
                        uvs.Add(textureCoordinate.x, textureCoordinate.y);
                    }

                    for (var i = 0; i < tessellation - 2; i++)
                    {
                        if (!isTop)
                        {
                            indices.Add(vbase);
                            indices.Add(vbase + (i + 2) % tessellation);
                            indices.Add(vbase + (i + 1) % tessellation);
                        }
                        else
                        {
                            indices.Add(vbase);
                            indices.Add(vbase + (i + 1) % tessellation);
                            indices.Add(vbase + (i + 2) % tessellation);
                        }
                    }
                });
            var _base = new Vector3(0, -1, 0).scale(height / 2);
            offset = new Vector3(0, 1, 0).scale(height / subdivisions);
            var stride = tessellation + 1;
            for (var i = 0; i <= tessellation; i++)
            {
                var circleVector = getCircleVector(i);
                var textureCoordinate = new Vector2(i / tessellation, 0);
                var radius = radiusBottom;
                for (var s = 0; s <= subdivisions; s++)
                {
                    var position = circleVector.scale(radius);
                    position.addInPlace(_base.add(offset.scale(s)));
                    textureCoordinate.y += 1 / subdivisions;
                    radius += (radiusTop - radiusBottom) / subdivisions;
                    positions.Add(position.x, position.y, position.z);
                    uvs.Add(textureCoordinate.x, textureCoordinate.y);
                }
            }

            subdivisions += 1;
            for (var s = 0; s < subdivisions - 1; s++)
            {
                for (var i = 0; i <= tessellation; i++)
                {
                    indices.Add(i * subdivisions + s);
                    indices.Add((i * subdivisions + (s + subdivisions)) % (stride * subdivisions));
                    indices.Add(i * subdivisions + (s + 1));
                    indices.Add(i * subdivisions + (s + 1));
                    indices.Add((i * subdivisions + (s + subdivisions)) % (stride * subdivisions));
                    indices.Add((i * subdivisions + (s + subdivisions + 1)) % (stride * subdivisions));
                }
            }

            createCylinderCap(true);
            createCylinderCap(false);
            ComputeNormals(positions, indices, normals);
            var vertexData = new VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }

        /// <summary>
        /// </summary>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <param name="subdivisions">
        /// </param>
        /// <returns>
        /// </returns>
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
                    var position = new Vector3((col * width) / subdivisions - (width / 2.0), 0, ((subdivisions - row) * height) / subdivisions - (height / 2.0));
                    var normal = new Vector3(0, 1.0, 0);
                    positions.Add(position.x, position.y, position.z);
                    normals.Add(normal.x, normal.y, normal.z);
                    uvs.Add(col / subdivisions, 1.0 - row / subdivisions);
                }
            }

            for (var row = 0; row < subdivisions; row++)
            {
                for (var col = 0; col < subdivisions; col++)
                {
                    indices.Add(col + 1 + (row + 1) * (subdivisions + 1));
                    indices.Add(col + 1 + row * (subdivisions + 1));
                    indices.Add(col + row * (subdivisions + 1));
                    indices.Add(col + (row + 1) * (subdivisions + 1));
                    indices.Add(col + 1 + (row + 1) * (subdivisions + 1));
                    indices.Add(col + row * (subdivisions + 1));
                }
            }

            var vertexData = new VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }

        /// <summary>
        /// </summary>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <param name="subdivisions">
        /// </param>
        /// <param name="minHeight">
        /// </param>
        /// <param name="maxHeight">
        /// </param>
        /// <param name="buffer">
        /// </param>
        /// <param name="bufferWidth">
        /// </param>
        /// <param name="bufferHeight">
        /// </param>
        /// <returns>
        /// </returns>
        public static VertexData CreateGroundFromHeightMap(
            double width, double height, int subdivisions, double minHeight, double maxHeight, Uint8Array buffer, double bufferWidth, double bufferHeight)
        {
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            for (var row = 0; row <= subdivisions; row++)
            {
                for (var col = 0; col <= subdivisions; col++)
                {
                    var position = new Vector3((col * width) / subdivisions - (width / 2.0), 0, ((subdivisions - row) * height) / subdivisions - (height / 2.0));
                    var heightMapX = ((position.x + width / 2) / width) * (bufferWidth - 1);
                    var heightMapY = (1.0 - (position.z + height / 2) / height) * (bufferHeight - 1);
                    var pos = (int)(heightMapX + heightMapY * bufferWidth) * 4;
                    var r = buffer[pos] / 255.0;
                    var g = buffer[pos + 1] / 255.0;
                    var b = buffer[pos + 2] / 255.0;
                    var gradient = r * 0.3 + g * 0.59 + b * 0.11;
                    position.y = minHeight + (maxHeight - minHeight) * gradient;
                    positions.Add(position.x, position.y, position.z);
                    normals.Add(0, 0, 0);
                    uvs.Add(col / subdivisions, 1.0 - row / subdivisions);
                }
            }

            for (var row = 0; row < subdivisions; row++)
            {
                for (var col = 0; col < subdivisions; col++)
                {
                    indices.Add(col + 1 + (row + 1) * (subdivisions + 1));
                    indices.Add(col + 1 + row * (subdivisions + 1));
                    indices.Add(col + row * (subdivisions + 1));
                    indices.Add(col + (row + 1) * (subdivisions + 1));
                    indices.Add(col + 1 + (row + 1) * (subdivisions + 1));
                    indices.Add(col + row * (subdivisions + 1));
                }
            }

            ComputeNormals(positions, indices, normals);
            var vertexData = new VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }

        /// <summary>
        /// </summary>
        /// <param name="points">
        /// </param>
        /// <returns>
        /// </returns>
        public static VertexData CreateLines(Array<Vector3> points)
        {
            var indices = new Array<int>();
            var positions = new Array<double>();
            for (var index = 0; index < points.Length; index++)
            {
                positions.Add(points[index].x, points[index].y, points[index].z);
                if (index > 0)
                {
                    indices.Add(index - 1);
                    indices.Add(index);
                }
            }

            var vertexData = new VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            return vertexData;
        }

        /// <summary>
        /// </summary>
        /// <param name="size">
        /// </param>
        /// <returns>
        /// </returns>
        public static VertexData CreatePlane(double size = 1)
        {
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            var halfSize = size / 2.0;
            positions.Add(-halfSize, -halfSize, 0);
            normals.Add(0, 0, -1.0);
            uvs.Add(0.0, 0.0);
            positions.Add(halfSize, -halfSize, 0);
            normals.Add(0, 0, -1.0);
            uvs.Add(1.0, 0.0);
            positions.Add(halfSize, halfSize, 0);
            normals.Add(0, 0, -1.0);
            uvs.Add(1.0, 1.0);
            positions.Add(-halfSize, halfSize, 0);
            normals.Add(0, 0, -1.0);
            uvs.Add(0.0, 1.0);
            indices.Add(0);
            indices.Add(1);
            indices.Add(2);
            indices.Add(0);
            indices.Add(2);
            indices.Add(3);
            var vertexData = new VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }

        /// <summary>
        /// </summary>
        /// <param name="segments">
        /// </param>
        /// <param name="diameter">
        /// </param>
        /// <returns>
        /// </returns>
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
                var normalizedZ = zRotationStep / (double)totalZRotationSteps;
                var angleZ = normalizedZ * Math.PI;
                for (var yRotationStep = 0; yRotationStep <= totalYRotationSteps; yRotationStep++)
                {
                    var normalizedY = yRotationStep / (double)totalYRotationSteps;
                    var angleY = normalizedY * Math.PI * 2.0;
                    var rotationZ = Matrix.RotationZ(-angleZ);
                    var rotationY = Matrix.RotationY(angleY);
                    var afterRotZ = Vector3.TransformCoordinates(Vector3.Up(), rotationZ);
                    var complete = Vector3.TransformCoordinates(afterRotZ, rotationY);
                    var vertex = complete.scale(radius);
                    var normal = Vector3.Normalize(vertex);
                    positions.Add(vertex.x, vertex.y, vertex.z);
                    normals.Add(normal.x, normal.y, normal.z);
                    uvs.Add(normalizedZ, normalizedY);
                }

                if (zRotationStep > 0)
                {
                    var verticesCount = positions.Length / 3;
                    for (var firstIndex = verticesCount - 2 * (totalYRotationSteps + 1); (firstIndex + totalYRotationSteps + 2) < verticesCount; firstIndex++)
                    {
                        indices.Add(firstIndex);
                        indices.Add(firstIndex + 1);
                        indices.Add(firstIndex + totalYRotationSteps + 1);
                        indices.Add(firstIndex + totalYRotationSteps + 1);
                        indices.Add(firstIndex + 1);
                        indices.Add(firstIndex + totalYRotationSteps + 2);
                    }
                }
            }

            var vertexData = new VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }

        /// <summary>
        /// </summary>
        /// <param name="xmin">
        /// </param>
        /// <param name="zmin">
        /// </param>
        /// <param name="xmax">
        /// </param>
        /// <param name="zmax">
        /// </param>
        /// <param name="subdivisions">
        /// </param>
        /// <param name="precision">
        /// </param>
        /// <returns>
        /// </returns>
        public static VertexData CreateTiledGround(double xmin, double zmin, double xmax, double zmax, SizeI subdivisions, SizeI precision)
        {
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            subdivisions.h = (subdivisions.w < 1) ? 1 : subdivisions.h;
            subdivisions.w = (subdivisions.w < 1) ? 1 : subdivisions.w;
            precision.w = (precision.w < 1) ? 1 : precision.w;
            precision.h = (precision.h < 1) ? 1 : precision.h;
            var tileSize = new SizeI { w = (int)((xmax - xmin) / subdivisions.w), h = (int)((zmax - zmin) / subdivisions.h) };
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
                                _base + col + (row + 1) * rowLength);

                            indices.Add(square[1]);
                            indices.Add(square[2]);
                            indices.Add(square[3]);
                            indices.Add(square[0]);
                            indices.Add(square[1]);
                            indices.Add(square[3]);
                        }
                    }

                    // Position, normals and uvs
                    var position = Vector3.Zero();
                    var normal = new Vector3(0, 1.0, 0);
                    for (var row = 0; row <= precision.h; row++)
                    {
                        position.z = (row * (zTileMax - zTileMin)) / precision.h + zTileMin;
                        for (var col = 0; col <= precision.w; col++)
                        {
                            position.x = (col * (xTileMax - xTileMin)) / precision.w + xTileMin;
                            position.y = 0;

                            positions.Add(position.x, position.y, position.z);
                            normals.Add(normal.x, normal.y, normal.z);
                            uvs.Add(col / precision.w, row / precision.h);
                        }
                    }
                }
            }

            var vertexData = new VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }

        /// <summary>
        /// </summary>
        /// <param name="diameter">
        /// </param>
        /// <param name="thickness">
        /// </param>
        /// <param name="tessellation">
        /// </param>
        /// <returns>
        /// </returns>
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
                var transform = Matrix.Translation(diameter / 2.0, 0, 0).multiply(Matrix.RotationY(outerAngle));
                for (var j = 0; j <= tessellation; j++)
                {
                    var v = 1 - j / tessellation;
                    var innerAngle = j * Math.PI * 2.0 / tessellation + Math.PI;
                    var dx = Math.Cos(innerAngle);
                    var dy = Math.Sin(innerAngle);
                    var normal = new Vector3(dx, dy, 0);
                    var position = normal.scale(thickness / 2);
                    var textureCoordinate = new Vector2(u, v);
                    position = Vector3.TransformCoordinates(position, transform);
                    normal = Vector3.TransformNormal(normal, transform);
                    positions.Add(position.x, position.y, position.z);
                    normals.Add(normal.x, normal.y, normal.z);
                    uvs.Add(textureCoordinate.x, textureCoordinate.y);
                    var nextI = (i + 1) % stride;
                    var nextJ = (j + 1) % stride;
                    indices.Add(i * stride + j);
                    indices.Add(i * stride + nextJ);
                    indices.Add(nextI * stride + j);
                    indices.Add(i * stride + nextJ);
                    indices.Add(nextI * stride + nextJ);
                    indices.Add(nextI * stride + j);
                }
            }

            var vertexData = new VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }

        /// <summary>
        /// </summary>
        /// <param name="radius">
        /// </param>
        /// <param name="tube">
        /// </param>
        /// <param name="radialSegments">
        /// </param>
        /// <param name="tubularSegments">
        /// </param>
        /// <param name="p">
        /// </param>
        /// <param name="q">
        /// </param>
        /// <returns>
        /// </returns>
        public static VertexData CreateTorusKnot(
            double radius = 2, double tube = 0.5, int radialSegments = 32, int tubularSegments = 32, double p = 2, double q = 3)
        {
            var indices = new Array<int>();
            var positions = new Array<double>();
            var normals = new Array<double>();
            var uvs = new Array<double>();
            var getPos = new Func<double, Vector3>(
                angle =>
                {
                    var cu = Math.Cos(angle);
                    var su = Math.Sin(angle);
                    var quOverP = q / p * angle;
                    var cs = Math.Cos(quOverP);
                    var tx = radius * (2 + cs) * 0.5 * cu;
                    var ty = radius * (2 + cs) * su * 0.5;
                    var tz = radius * Math.Sin(quOverP) * 0.5;
                    return new Vector3(tx, ty, tz);
                });
            for (var i = 0; i <= radialSegments; i++)
            {
                var modI = i % radialSegments;
                var u = modI / radialSegments * 2 * p * Math.PI;
                var p1 = getPos(u);
                var p2 = getPos(u + 0.01);
                var tang = p2.subtract(p1);
                var n = p2.add(p1);
                var bitan = Vector3.Cross(tang, n);
                n = Vector3.Cross(bitan, tang);
                bitan.normalize();
                n.normalize();
                for (var j = 0; j < tubularSegments; j++)
                {
                    var modJ = j % tubularSegments;
                    var v = modJ / tubularSegments * 2 * Math.PI;
                    var cx = -tube * Math.Cos(v);
                    var cy = tube * Math.Sin(v);
                    positions.Add(p1.x + cx * n.x + cy * bitan.x);
                    positions.Add(p1.y + cx * n.y + cy * bitan.y);
                    positions.Add(p1.z + cx * n.z + cy * bitan.z);
                    uvs.Add(i / radialSegments);
                    uvs.Add(j / tubularSegments);
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
                    indices.Add(d);
                    indices.Add(b);
                    indices.Add(a);
                    indices.Add(d);
                    indices.Add(c);
                    indices.Add(b);
                }
            }

            ComputeNormals(positions, indices, normals);
            var vertexData = new VertexData();
            vertexData.indices = indices;
            vertexData.positions = positions;
            vertexData.normals = normals;
            vertexData.uvs = uvs;
            return vertexData;
        }

        /// <summary>
        /// </summary>
        /// <param name="geometry">
        /// </param>
        /// <returns>
        /// </returns>
        public static VertexData ExtractFromGeometry(Geometry geometry)
        {
            return _ExtractFrom(geometry);
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <returns>
        /// </returns>
        public static VertexData ExtractFromMesh(Mesh mesh)
        {
            return _ExtractFrom(mesh);
        }

        /// <summary>
        /// </summary>
        /// <param name="geometry">
        /// </param>
        /// <param name="updatable">
        /// </param>
        public virtual void applyToGeometry(Geometry geometry, bool updatable = false)
        {
            this._applyTo(geometry, updatable);
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <param name="updatable">
        /// </param>
        public virtual void applyToMesh(Mesh mesh, bool updatable = false)
        {
            this._applyTo(mesh, updatable);
        }

        /// <summary>
        /// </summary>
        /// <param name="other">
        /// </param>
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
                    this.indices.Add(other.indices[index] + offset);
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
                    this.positions.Add(other.positions[index]);
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
                    this.normals.Add(other.normals[index]);
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
                    this.uvs.Add(other.uvs[index]);
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
                    this.uv2s.Add(other.uv2s[index]);
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
                    this.matricesIndices.Add(other.matricesIndices[index]);
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
                    this.matricesWeights.Add(other.matricesWeights[index]);
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
                    this.colors.Add(other.colors[index]);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="data">
        /// </param>
        /// <param name="kind">
        /// </param>
        public virtual void set(Array<double> data, VertexBufferKind kind)
        {
            switch (kind)
            {
                case VertexBufferKind.PositionKind:
                    this.positions = data;
                    break;
                case VertexBufferKind.NormalKind:
                    this.normals = data;
                    break;
                case VertexBufferKind.UVKind:
                    this.uvs = data;
                    break;
                case VertexBufferKind.UV2Kind:
                    this.uv2s = data;
                    break;
                case VertexBufferKind.ColorKind:
                    this.colors = data;
                    break;
                case VertexBufferKind.MatricesIndicesKind:
                    this.matricesIndices = data;
                    break;
                case VertexBufferKind.MatricesWeightsKind:
                    this.matricesWeights = data;
                    break;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="matrix">
        /// </param>
        public virtual void transform(Matrix matrix)
        {
            var transformed = Vector3.Zero();
            if (this.positions != null)
            {
                var position = Vector3.Zero();
                for (var index = 0; index < this.positions.Length; index += 3)
                {
                    Vector3.FromArrayToRef(this.positions, index, position);
                    Vector3.TransformCoordinatesToRef(position, matrix, transformed);
                    this.positions[index] = transformed.x;
                    this.positions[index + 1] = transformed.y;
                    this.positions[index + 2] = transformed.z;
                }
            }

            if (this.normals != null)
            {
                var normal = Vector3.Zero();
                for (var index = 0; index < this.normals.Length; index += 3)
                {
                    Vector3.FromArrayToRef(this.normals, index, normal);
                    Vector3.TransformNormalToRef(normal, matrix, transformed);
                    this.normals[index] = transformed.x;
                    this.normals[index + 1] = transformed.y;
                    this.normals[index + 2] = transformed.z;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="geometry">
        /// </param>
        /// <param name="updateExtends">
        /// </param>
        /// <param name="makeItUnique">
        /// </param>
        public virtual void updateGeometry(Geometry geometry, bool updateExtends = false, bool makeItUnique = false)
        {
            this._update(geometry);
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <param name="updateExtends">
        /// </param>
        /// <param name="makeItUnique">
        /// </param>
        public virtual void updateMesh(Mesh mesh, bool updateExtends = false, bool makeItUnique = false)
        {
            this._update(mesh);
        }

        /// <summary>
        /// </summary>
        /// <param name="meshOrGeometry">
        /// </param>
        /// <returns>
        /// </returns>
        private static VertexData _ExtractFrom(IGetSetVerticesData meshOrGeometry)
        {
            var result = new VertexData();
            if (meshOrGeometry.isVerticesDataPresent(VertexBufferKind.PositionKind))
            {
                result.positions = meshOrGeometry.getVerticesData(VertexBufferKind.PositionKind);
            }

            if (meshOrGeometry.isVerticesDataPresent(VertexBufferKind.NormalKind))
            {
                result.normals = meshOrGeometry.getVerticesData(VertexBufferKind.NormalKind);
            }

            if (meshOrGeometry.isVerticesDataPresent(VertexBufferKind.UVKind))
            {
                result.uvs = meshOrGeometry.getVerticesData(VertexBufferKind.UVKind);
            }

            if (meshOrGeometry.isVerticesDataPresent(VertexBufferKind.UV2Kind))
            {
                result.uv2s = meshOrGeometry.getVerticesData(VertexBufferKind.UV2Kind);
            }

            if (meshOrGeometry.isVerticesDataPresent(VertexBufferKind.ColorKind))
            {
                result.colors = meshOrGeometry.getVerticesData(VertexBufferKind.ColorKind);
            }

            if (meshOrGeometry.isVerticesDataPresent(VertexBufferKind.MatricesIndicesKind))
            {
                result.matricesIndices = meshOrGeometry.getVerticesData(VertexBufferKind.MatricesIndicesKind);
            }

            if (meshOrGeometry.isVerticesDataPresent(VertexBufferKind.MatricesWeightsKind))
            {
                result.matricesWeights = meshOrGeometry.getVerticesData(VertexBufferKind.MatricesWeightsKind);
            }

            result.indices = meshOrGeometry.getIndices();
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="meshOrGeometry">
        /// </param>
        /// <param name="updatable">
        /// </param>
        private void _applyTo(IGetSetVerticesData meshOrGeometry, bool updatable = false)
        {
            if (this.positions != null)
            {
                meshOrGeometry.setVerticesData(VertexBufferKind.PositionKind, this.positions, updatable);
            }

            if (this.normals != null)
            {
                meshOrGeometry.setVerticesData(VertexBufferKind.NormalKind, this.normals, updatable);
            }

            if (this.uvs != null)
            {
                meshOrGeometry.setVerticesData(VertexBufferKind.UVKind, this.uvs, updatable);
            }

            if (this.uv2s != null)
            {
                meshOrGeometry.setVerticesData(VertexBufferKind.UV2Kind, this.uv2s, updatable);
            }

            if (this.colors != null)
            {
                meshOrGeometry.setVerticesData(VertexBufferKind.ColorKind, this.colors, updatable);
            }

            if (this.matricesIndices != null)
            {
                meshOrGeometry.setVerticesData(VertexBufferKind.MatricesIndicesKind, this.matricesIndices, updatable);
            }

            if (this.matricesWeights != null)
            {
                meshOrGeometry.setVerticesData(VertexBufferKind.MatricesWeightsKind, this.matricesWeights, updatable);
            }

            if (this.indices != null)
            {
                meshOrGeometry.setIndices(this.indices);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="meshOrGeometry">
        /// </param>
        /// <param name="updateExtends">
        /// </param>
        /// <param name="makeItUnique">
        /// </param>
        private void _update(IGetSetVerticesData meshOrGeometry, bool updateExtends = false, bool makeItUnique = false)
        {
            if (this.positions != null)
            {
                meshOrGeometry.updateVerticesData(VertexBufferKind.PositionKind, this.positions, updateExtends, makeItUnique);
            }

            if (this.normals != null)
            {
                meshOrGeometry.updateVerticesData(VertexBufferKind.NormalKind, this.normals, updateExtends, makeItUnique);
            }

            if (this.uvs != null)
            {
                meshOrGeometry.updateVerticesData(VertexBufferKind.UVKind, this.uvs, updateExtends, makeItUnique);
            }

            if (this.uv2s != null)
            {
                meshOrGeometry.updateVerticesData(VertexBufferKind.UV2Kind, this.uv2s, updateExtends, makeItUnique);
            }

            if (this.colors != null)
            {
                meshOrGeometry.updateVerticesData(VertexBufferKind.ColorKind, this.colors, updateExtends, makeItUnique);
            }

            if (this.matricesIndices != null)
            {
                meshOrGeometry.updateVerticesData(VertexBufferKind.MatricesIndicesKind, this.matricesIndices, updateExtends, makeItUnique);
            }

            if (this.matricesWeights != null)
            {
                meshOrGeometry.updateVerticesData(VertexBufferKind.MatricesWeightsKind, this.matricesWeights, updateExtends, makeItUnique);
            }

            if (this.indices != null)
            {
                meshOrGeometry.setIndices(this.indices);
            }
        }
    }
}