using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

//扩展类
//静态类下面的方法都必须是静态方法。
public static class PostProcessorExtend
{
    #region[模型设置]
    //静态类在重载时不用实例化，否则非静态类重载时要先实例化
    public static void SetModelScene(this ModelImporter importer)
    {

        importer.globalScale = 1f;
        importer.useFileScale = true;
        importer.importBlendShapes = false;
        importer.importVisibility = true;
        importer.importCameras = false;
        importer.importLights = false;
        importer.preserveHierarchy = false;
        importer.sortHierarchyByName = false;
    }

    //多行参数的扩展类下面的方法，在第一个行参数前面添加this就可以改成扩展方法
    public static void SetModelMesh(this ModelImporter importer, bool isAddCollider = false)
    {
        importer.meshCompression = ModelImporterMeshCompression.Medium;
        importer.isReadable = false;
        importer.optimizeMeshPolygons = true;
        importer.optimizeMeshVertices = true;
        importer.addCollider = isAddCollider;
    }

    public static void SetModelGeometry(this ModelImporter importer, bool isImporterNormal, bool isImporterTangent, bool isGenerateUV2)
    {
        importer.keepQuads = false;
        //焊接顶点
        importer.weldVertices = true;
        importer.indexFormat = ModelImporterIndexFormat.Auto;
        if (isImporterNormal)
        {
            //导入法线
            importer.importNormals = ModelImporterNormals.Import;
            importer.importBlendShapeNormals = importer.importNormals;
            importer.normalCalculationMode = ModelImporterNormalCalculationMode.AreaAndAngleWeighted;
            importer.normalSmoothingSource = ModelImporterNormalSmoothingSource.FromAngle;
            importer.normalSmoothingAngle = 60;
            if (isImporterTangent)
            {
                //打入切线
                importer.importTangents = ModelImporterTangents.Import;
            }
            else
            {
                importer.importTangents = ModelImporterTangents.None;
            }
            //三元运算符
            //importer.importTangents = isImporterTangent ? importer.importTangents = ModelImporterTangents.Import : importer.importTangents = ModelImporterTangents.None;
        }
        else
        {
            importer.importNormals = ModelImporterNormals.None;
            //导入切线为none
            importer.importTangents = ModelImporterTangents.None;
        }
        //importer.importBlendShapeNormals = false;

        importer.swapUVChannels = false;
        importer.generateSecondaryUV = isGenerateUV2;

    }
    #endregion

    #region[动画设置]
    //蒙皮设置
    public static void SetModelRig(this ModelImporter importer,bool isImportRig)
    {
        if(isImportRig)
        {
            //importer.animationType = ModelImporterAnimationType.Generic;
            importer.animationType = ModelImporterAnimationType.Generic;
            importer.avatarSetup = ModelImporterAvatarSetup.NoAvatar;
            importer.skinWeights = ModelImporterSkinWeights.Standard;
        }
        else
        {
            importer.animationType = ModelImporterAnimationType.None;
        }
        
    }

    public static void SetModelAnimation(this ModelImporter importer,bool isImportAnimation)
    {
        importer.importConstraints = false;
        importer.importAnimation = isImportAnimation;
        importer.resampleCurves = true;
        importer.animationCompression = ModelImporterAnimationCompression.KeyframeReductionAndCompression;
        //importer.importBlendShapeDeformPercent = false;
        importer.importAnimatedCustomProperties = false;
    }


    #endregion

    #region[Materials]
    public static void SetModelMaterials(this ModelImporter importer,bool isImporterMaterials)
    {
        importer.materialImportMode = isImporterMaterials ? ModelImporterMaterialImportMode.ImportStandard : ModelImporterMaterialImportMode.None;
        importer.useSRGBMaterialColor = true;
        importer.materialLocation = ModelImporterMaterialLocation.External;
        importer.materialName = ModelImporterMaterialName.BasedOnTextureName;
        importer.materialSearch = ModelImporterMaterialSearch.Local;
    }
    #endregion

    #region[Texture]
    //行参数的默认值

    public static void SetTextureType(this TextureImporter textureImporter, TextureImporterType textureType =  TextureImporterType.Default,
        TextureImporterShape texShape = TextureImporterShape.Texture2D,bool issRGB = true)
    {
        //string texNormalMap = Path.GetFileName(assetPath);

     
        textureImporter.textureType = textureType;
        textureImporter.textureShape = texShape;
        textureImporter.sRGBTexture = issRGB;
        textureImporter.alphaSource = textureImporter.DoesSourceTextureHaveAlpha() ? TextureImporterAlphaSource.FromInput : TextureImporterAlphaSource.None;
        textureImporter.alphaIsTransparency = false;

        textureImporter.npotScale = TextureImporterNPOTScale.ToNearest;
    }
    #endregion

}
