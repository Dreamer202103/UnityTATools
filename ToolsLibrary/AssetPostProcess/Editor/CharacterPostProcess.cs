using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CharacterPostProcess : AssetPostprocessor
{
    const string PATH = "Assets/Arts/Character/";
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
            string name = Path.GetFileName(assetPath);
            #region[SetModelScence]
            //importer.globalScale = 1f;
            //importer.useFileScale = true;
            //importer.importBlendShapes = false;
            //importer.importVisibility = true;
            //importer.importCameras = false;
            //importer.importLights = false;
            //importer.preserveHierarchy = false;
            //importer.sortHierarchyByName = false;
            #endregion
            importer.SetModelScene();

            #region[SetModelMesh]
            //importer.meshCompression = ModelImporterMeshCompression.Medium;
            //importer.isReadable = false;
            //importer.optimizeMeshPolygons = true;
            //importer.optimizeMeshVertices = true;
            //importer.addCollider = false;
            #endregion
            importer.SetModelMesh();

            importer.SetModelGeometry(true, true, false);
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

            importer.SetModelRig(true);
            #region[SetModelRig]
            //Rig
            //importer.animationType = ModelImporterAnimationType.Generic;
            //importer.avatarSetup = ModelImporterAvatarSetup.NoAvatar;
            //importer.skinWeights = ModelImporterSkinWeights.Standard;
            #endregion

            if(name.Contains("@"))
            {
                importer.SetModelAnimation(true);
                importer.SetModelMaterials(true);


            }
            else
            {
                importer.SetModelAnimation(false);
                importer.SetModelMaterials(false);

            }
            #region[Animation]
            //if (name.Contains("@"))
            //{
            //    importer.importConstraints = false;
            //    importer.importAnimation = true;
            //    importer.resampleCurves = true;
            //    importer.animationCompression = ModelImporterAnimationCompression.KeyframeReductionAndCompression;
            //    //importer.importBlendShapeDeformPercent = false;
            //    importer.importAnimatedCustomProperties = false;
            //    //materials
            //    importer.materialImportMode = ModelImporterMaterialImportMode.None;
            //    importer.useSRGBMaterialColor = true;


            //}
            //else
            //{
            //    importer.importConstraints = false;
            //    importer.importAnimation = false;
            //    //materials
            //    importer.materialImportMode = ModelImporterMaterialImportMode.ImportStandard;
            //    importer.useSRGBMaterialColor = true;
            //    importer.materialLocation = ModelImporterMaterialLocation.External;
            //    importer.materialName = ModelImporterMaterialName.BasedOnTextureName;
            //    importer.materialSearch = ModelImporterMaterialSearch.Local;


            //}
            #endregion

        }
    }
    #endregion


    //在第一次创建材质球时才运行
    //void OnPostprocessMaterial(Material material)
    //{
    //    //material.shader = Shader.Find();
    //}
    #region[纹理设置]
    void OnPreprocessTexture()
    {
        //路径判断器
        if(assetPath.Contains(PATH))
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            string texNormalMap = Path.GetFileName(assetPath);

            if(texNormalMap.Contains("_Normal"))
            {
                textureImporter.textureType = TextureImporterType.NormalMap;
            }
            textureImporter.textureType = TextureImporterType.Default;
            textureImporter.textureShape = TextureImporterShape.Texture2D;
            textureImporter.sRGBTexture = true;
            if(textureImporter.DoesSourceTextureHaveAlpha())
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

        }
    }
    #endregion




}
