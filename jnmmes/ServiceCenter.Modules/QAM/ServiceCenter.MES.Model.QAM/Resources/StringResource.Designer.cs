﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceCenter.MES.Model.QAM.Resources {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ServiceCenter.MES.Model.QAM.Resources.StringResource", typeof(StringResource).Assembly);
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
        ///   查找类似 手工 的本地化字符串。
        /// </summary>
        internal static string EnumCheckAction_None {
            get {
                return ResourceManager.GetString("EnumCheckAction_None", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 进站后 的本地化字符串。
        /// </summary>
        internal static string EnumCheckAction_TrackIn {
            get {
                return ResourceManager.GetString("EnumCheckAction_TrackIn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 按分钟间隔 的本地化字符串。
        /// </summary>
        internal static string EnumCheckMode_Interval {
            get {
                return ResourceManager.GetString("EnumCheckMode_Interval", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 每批 的本地化字符串。
        /// </summary>
        internal static string EnumCheckMode_Lot {
            get {
                return ResourceManager.GetString("EnumCheckMode_Lot", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 按批次数量 的本地化字符串。
        /// </summary>
        internal static string EnumCheckMode_LotQty {
            get {
                return ResourceManager.GetString("EnumCheckMode_LotQty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 按数量 的本地化字符串。
        /// </summary>
        internal static string EnumCheckMode_Qty {
            get {
                return ResourceManager.GetString("EnumCheckMode_Qty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 正常 的本地化字符串。
        /// </summary>
        internal static string EnumCheckType_Normal {
            get {
                return ResourceManager.GetString("EnumCheckType_Normal", resourceCulture);
            }
        }
    }
}
