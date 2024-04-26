using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SimpleCalcaulatorEditorWindow : EditorWindow
{
    public string name;
    public int score;
    private string labelNumber = "0";
    private string op;
    private float number01, number02;
    //Atrribute特性，可放在字段和方法和类上，本身的功能进行了加强
    //中括号时特性的
    //CONTEXT可以指定一个组件
    //MenuItem做自定义界面最基本的方法
    [MenuItem("Tools/Simple Calculator...", false, 1)]
    static void Open()
    {
        // var window = new SimpleCalcaulatorEditorWindow();
        var window = EditorWindow.GetWindow(typeof(SimpleCalcaulatorEditorWindow), false, "window");
        //window.Show();
        //窗口的最大化，只是在工具栏嵌入到uityui中
        window.maximized = true;
        window.maxSize = new Vector2(362, 288);
        window.minSize = new Vector2(362, 288);
        //window.position = new Rect(200, 100, 100, 200);
        Texture tex = AssetDatabase.LoadAssetAtPath<Texture>("Assets/ToolsLibrary/SimpleCalculator/Editor/Icon_Calcaulor.jpg");
        //gui
        window.titleContent = new GUIContent("简易计算器", tex);
        window.Show();
    }

    //当UI在移动的时候才更新
    void OnGUI()
    {
        var skin = (GUISkin)EditorGUIUtility.Load("Assets/ToolsLibrary/SimpleCalculator/Editor/CalcaulatorSkin.guiskin");

        GUI.skin = skin;

        GUIStyle _style01 = new GUIStyle(EditorStyles.textField);
        _style01.fontSize = 20;
        _style01.wordWrap = true;

        
        //GUIContent _content = new GUIContent("这是一个文本");
        EditorGUILayout.LabelField(labelNumber, skin.textField);

        //按下，松开才有响应
        //if(GUILayout.Button("9"))
        //{
        //    Debug.LogError("9");
        //}
        #region[绘制按钮]
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.BeginVertical(skin.box);
            {
                //引用水平组
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("7",skin.button))
                {
                    if(labelNumber =="0")
                    {
                        labelNumber = "7";
                    }
                    else
                    {
                        labelNumber += "7";
                    }
                    
                }
                if (GUILayout.Button("8", skin.button))
                {
                    if (labelNumber == "0")
                    {
                        labelNumber = "8";
                    }
                    else
                    {
                        labelNumber += "8";
                    }
                }
                if (GUILayout.Button("9", skin.button))
                {
                    if (labelNumber == "0")
                    {
                        labelNumber = "9";
                    }
                    else
                    {
                        labelNumber += "9";
                    }
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("4", skin.button))
                {
                    //三元运算，如果labekNumber等于0，那么labelNumber等于4，否则等于labelNumber+4.
                    labelNumber = labelNumber == "0" ? "4":labelNumber + 4;
                }
                if (GUILayout.Button("5", skin.button))
                {
                    labelNumber = labelNumber == "0" ? "5" : labelNumber + 5;
                }
                if (GUILayout.Button("6", skin.button))
                {
                    labelNumber = labelNumber == "0" ? "6" : labelNumber + 6;
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("1", skin.button))
                {
                    labelNumber = labelNumber == "0" ? "1" : labelNumber + 1;
                }
                if (GUILayout.Button("2", skin.button))
                {
                    labelNumber = labelNumber == "0" ? "2" : labelNumber + 2;
                }
                if (GUILayout.Button("3", skin.button))
                {
                    labelNumber = labelNumber == "0" ? "3" : labelNumber + 3;
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("0", skin.button))
                {
                    labelNumber = labelNumber == "0" ? "0" : labelNumber + 0;
                }
                if (GUILayout.Button("C", skin.button))
                {
                    labelNumber = "0";
                }
                if(GUILayout.Button("=",skin.button))
                {
                    number02 = float.Parse(labelNumber);
                    if(op == "+")
                    {
                        float r = number01 + number02;
                        labelNumber = r.ToString();
                    }
                    else if(op == "-")
                    {
                        float r = number01 - number02;
                        labelNumber = r.ToString();
                    }
                    else if(op=="X")
                    {
                        float r = number01 * number02;
                        labelNumber = r.ToString();
                    }
                    else if(op=="/")
                    {
                        if (number02 != 0)
                        {
                            float r = number01 / number02;
                            labelNumber = r.ToString();
                        }
                        else
                        {
                            labelNumber = "0";
                        }
                        
                    }
                  
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            {
                //EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("+", skin.button))
                {
                    number01 = float.Parse(labelNumber);
                    labelNumber = "0";
                    op = "+";
                }
                if(GUILayout.Button("-",skin.button))
                {
                    number01 = float.Parse(labelNumber);
                    labelNumber = "0";
                    op = "-";
                }
                if (GUILayout.Button("X",skin.button))
                {
                    number01 = float.Parse(labelNumber);
                    labelNumber = "0";
                    op = "X";
                }
                if (GUILayout.Button("/",skin.button))
                {
                    number01 = float.Parse(labelNumber);
                    labelNumber = "0";
                    op = "/";
                }
                //EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }
        

        EditorGUILayout.BeginHorizontal();

        




        #endregion

        #region[RepeatButton]
        //按下一直在响应
        //if (GUILayout.RepeatButton("Repeat"))
        //{
        //    Debug.LogError("9");
        //}
        #endregion

    }

    // [MenuItem("Tools/Simple Calculator...", true)]
    // static bool OpenValidate()
    // {
    //     // return false;
    //     return Selection.activeGameObject != null;
    // }

    // [MenuItem("Tools/Test", false, 0)]
    // static void OpenTest()
    // {
    //     var window = new SimpleCalcaulatorEditorWindow();
    //     window.Show();
    // }
}
