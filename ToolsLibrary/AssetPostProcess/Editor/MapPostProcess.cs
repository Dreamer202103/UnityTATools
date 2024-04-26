using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapPostProcess : AssetPostprocessor
{
    const string PATH = "Assets/Arts/Maps/";
    #region[OnPreprocessAsset方法Mthode]
    ////当任何类型资源被导入时执行
    //void OnPreprocessAsset()
    //{
    //    Debug.LogError("OnPreprocessAsset");
    //}
    #endregion


    #region[OnPreprocessModel方法Mthode]
    //当模型资源导入时执行
    void OnPreprocessModel()
    {
        if(assetPath.Contains(PATH))
        {
            ModelImporter importer = (ModelImporter)assetImporter;
            //
            importer.SetModelScene();
            //PostProcessorExtend.SetModelScene(importer);

            #region[SetModelScene]
            //importer.isReadable = true;
            //importer.globalScale = 0.5f;
            //importer.useFileScale = true;
            //importer.importBlendShapes = false;
            //importer.importVisibility = true;
            //importer.importCameras = false;
            //importer.importLights = false;
            //importer.preserveHierarchy = false;
            //importer.sortHierarchyByName = false;
            #endregion

            //PostProcessorExtend.SetModelMesh(importer, false);
            importer.SetModelMesh();
            #region[SetModelMesh]
            //importer.meshCompression = ModelImporterMeshCompression.Medium;
            //importer.isReadable = false;
            //importer.optimizeMeshPolygons = true;
            //importer.optimizeMeshVertices = true;
            //importer.addCollider = false;
            #endregion

            importer.SetModelGeometry(true,false,true);
            #region[SetModelGeometry]
            //importer.keepQuads = false;
            //importer.weldVertices = true;
            //importer.indexFormat = ModelImporterIndexFormat.Auto;
            ////importer.importBlendShapeNormals = false;
            //importer.importNormals = ModelImporterNormals.Import;
            //importer.importBlendShapeNormals = importer.importNormals;
            //importer.normalCalculationMode = ModelImporterNormalCalculationMode.AreaAndAngleWeighted;
            //importer.normalSmoothingSource = ModelImporterNormalSmoothingSource.FromAngle;
            //importer.normalSmoothingAngle = 60;
            //importer.importTangents = ModelImporterTangents.Import;
            //importer.swapUVChannels = false;
            //importer.generateSecondaryUV = true;
            #endregion

            importer.SetModelRig(false);
            #region[SetModelRig]
            //Rig
            //importer.animationType = ModelImporterAnimationType.None;
            //importer.avatarSetup = ModelImporterAvatarSetup.NoAvatar;
            //importer.skinWeights = ModelImporterSkinWeights.Standard;
            #endregion

            importer.SetModelAnimation(false);

            importer.SetModelMaterials(true);



            //materials
            //    importer.materialImportMode = ModelImporterMaterialImportMode.ImportStandard;
            //    importer.useSRGBMaterialColor = true;
            //    importer.materialLocation = ModelImporterMaterialLocation.External;
            //    importer.materialName = ModelImporterMaterialName.BasedOnTextureName;
            //    importer.materialSearch = ModelImporterMaterialSearch.Local;
        }

        #region[纹理设置]
        void OnPreprocessTexture()
        {
            //路径判断器
            if (assetPath.Contains(PATH))
            {
                TextureImporter textureImporter = (TextureImporter)assetImporter;

                textureImporter.textureType = TextureImporterType.Default;
                textureImporter.textureShape = TextureImporterShape.Texture2D;
                textureImporter.sRGBTexture = true;
                if (textureImporter.DoesSourceTextureHaveAlpha())
                {
                    textureImporter.alphaSource = TextureImporterAlphaSource.FromInput;
                    textureImporter.alphaIsTransparency = true;
                }
                else
                {
                    textureImporter.alphaSource = TextureImporterAlphaSource.None;
                    textureImporter.alphaIsTransparency = false;
                }

                //textureImporter.alphaIsTransparency = false;

                textureImporter.npotScale = TextureImporterNPOTScale.ToNearest;
                //关闭它节省内存
                textureImporter.isReadable = false;
                textureImporter.streamingMipmaps = false;
                textureImporter.mipmapEnabled = true;
                textureImporter.borderMipmap = false;
                textureImporter.mipmapFilter = TextureImporterMipFilter.BoxFilter;
                textureImporter.mipMapsPreserveCoverage = false;
                textureImporter.fadeout = false;
                textureImporter.wrapMode = TextureWrapMode.Repeat;
                textureImporter.filterMode = FilterMode.Bilinear;
                textureImporter.anisoLevel = 1;

                TextureImporterPlatformSettings _plateform = textureImporter.GetDefaultPlatformTextureSettings();
                _plateform.maxTextureSize = 512;
                _plateform.resizeAlgorithm = TextureResizeAlgorithm.Bilinear;
                _plateform.format = TextureImporterFormat.Automatic;
                _plateform.textureCompression = TextureImporterCompression.CompressedHQ;
                //可以减少内存
                _plateform.crunchedCompression = true;
                _plateform.compressionQuality = 100;
                textureImporter.SetPlatformTextureSettings(_plateform);

                TextureImporterPlatformSettings _plateStandalone = textureImporter.GetPlatformTextureSettings("Standalone");
                _plateStandalone.overridden = true;
                _plateStandalone.maxTextureSize = 2048;
                _plateStandalone.resizeAlgorithm = TextureResizeAlgorithm.Bilinear;
                _plateStandalone.format = TextureImporterFormat.RGBA32;
                _plateStandalone.textureCompression = TextureImporterCompression.Uncompressed;
                _plateStandalone.crunchedCompression = false;
                textureImporter.SetPlatformTextureSettings(_plateStandalone);

            }
        }
        #endregion


    }
    #endregion





}
