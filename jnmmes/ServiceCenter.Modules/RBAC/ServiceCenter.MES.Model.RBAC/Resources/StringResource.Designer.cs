﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceCenter.MES.Model.RBAC.Resources {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StringResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringResource() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ServiceCenter.MES.Model.RBAC.Resources.StringResource", typeof(StringResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 设备状态 的本地化字符串。
        /// </summary>
        internal static string ResourceType_EquipmentState {
            get {
                return ResourceManager.GetString("ResourceType_EquipmentState", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 线边仓 的本地化字符串。
        /// </summary>
        internal static string ResourceType_LineStore {
            get {
                return ResourceManager.GetString("ResourceType_LineStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 菜单 的本地化字符串。
        /// </summary>
        internal static string ResourceType_Menu {
            get {
                return ResourceManager.GetString("ResourceType_Menu", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 菜单项 的本地化字符串。
        /// </summary>
        internal static string ResourceType_MenuItem {
            get {
                return ResourceManager.GetString("ResourceType_MenuItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 菜单项功能 的本地化字符串。
        /// </summary>
        internal static string ResourceType_MenuItemFunction {
            get {
                return ResourceManager.GetString("ResourceType_MenuItemFunction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 菜单项分隔 的本地化字符串。
        /// </summary>
        internal static string ResourceType_MenuSeparate {
            get {
                return ResourceManager.GetString("ResourceType_MenuSeparate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 生产线 的本地化字符串。
        /// </summary>
        internal static string ResourceType_ProductionLine {
            get {
                return ResourceManager.GetString("ResourceType_ProductionLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 工序 的本地化字符串。
        /// </summary>
        internal static string ResourceType_RouteOperation {
            get {
                return ResourceManager.GetString("ResourceType_RouteOperation", resourceCulture);
            }
        }
    }
}
