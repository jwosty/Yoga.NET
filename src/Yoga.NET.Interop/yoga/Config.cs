using System.Runtime.InteropServices;

namespace Yoga.NET.Interop
{
    [NativeTypeName("struct Config : YGConfig")]
    public unsafe partial struct Config
    {
        [NativeTypeName("YGCloneNodeFunc")]
        private delegate* unmanaged[Cdecl]<YGNode*, YGNode*, nuint, YGNode*> cloneNodeCallback_;

        [NativeTypeName("YGLogger")]
        private delegate* unmanaged[Cdecl]<YGConfig*, YGNode*, YGLogLevel, sbyte*, sbyte*, int> logger_;

        public bool _bitfield;

        [NativeTypeName("bool : 1")]
        private bool useWebDefaults_
        {
            readonly get
            {
                return (bool)(_bitfield & 0x1);
            }

            set
            {
                _bitfield = (bool)((_bitfield & ~0x1) | (value & 0x1));
            }
        }

        [NativeTypeName("uint32_t")]
        private uint version_;

        [NativeTypeName("facebook::yoga::ExperimentalFeatureSet")]
        private byte experimentalFeatures_;

        [NativeTypeName("facebook::yoga::Errata")]
        private Errata errata_;

        private float pointScaleFactor_;

        private void* context_;

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga6Config17setUseWebDefaultsEb", ExactSpelling = true)]
        public static extern void setUseWebDefaults(Config* pThis, [NativeTypeName("bool")] byte useWebDefaults);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga6Config14useWebDefaultsEv", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte useWebDefaults(Config* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga6Config29setExperimentalFeatureEnabledENS0_19ExperimentalFeatureEb", ExactSpelling = true)]
        public static extern void setExperimentalFeatureEnabled(Config* pThis, [NativeTypeName("facebook::yoga::ExperimentalFeature")] ExperimentalFeature feature, [NativeTypeName("bool")] byte enabled);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga6Config28isExperimentalFeatureEnabledENS0_19ExperimentalFeatureE", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte isExperimentalFeatureEnabled(Config* pThis, [NativeTypeName("facebook::yoga::ExperimentalFeature")] ExperimentalFeature feature);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga6Config21getEnabledExperimentsEv", ExactSpelling = true)]
        [return: NativeTypeName("facebook::yoga::ExperimentalFeatureSet")]
        public static extern byte getEnabledExperiments(Config* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga6Config9setErrataENS0_6ErrataE", ExactSpelling = true)]
        public static extern void setErrata(Config* pThis, [NativeTypeName("facebook::yoga::Errata")] Errata errata);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga6Config9addErrataENS0_6ErrataE", ExactSpelling = true)]
        public static extern void addErrata(Config* pThis, [NativeTypeName("facebook::yoga::Errata")] Errata errata);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga6Config12removeErrataENS0_6ErrataE", ExactSpelling = true)]
        public static extern void removeErrata(Config* pThis, [NativeTypeName("facebook::yoga::Errata")] Errata errata);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga6Config9getErrataEv", ExactSpelling = true)]
        [return: NativeTypeName("facebook::yoga::Errata")]
        public static extern Errata getErrata(Config* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga6Config9hasErrataENS0_6ErrataE", ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte hasErrata(Config* pThis, [NativeTypeName("facebook::yoga::Errata")] Errata errata);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga6Config19setPointScaleFactorEf", ExactSpelling = true)]
        public static extern void setPointScaleFactor(Config* pThis, float pointScaleFactor);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga6Config19getPointScaleFactorEv", ExactSpelling = true)]
        public static extern float getPointScaleFactor(Config* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga6Config10setContextEPv", ExactSpelling = true)]
        public static extern void setContext(Config* pThis, void* context);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga6Config10getContextEv", ExactSpelling = true)]
        public static extern void* getContext(Config* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga6Config10getVersionEv", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint getVersion(Config* pThis);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga6Config9setLoggerEPFiPK8YGConfigPK6YGNode10YGLogLevelPKcPcE", ExactSpelling = true)]
        public static extern void setLogger(Config* pThis, [NativeTypeName("YGLogger")] delegate* unmanaged[Cdecl]<YGConfig*, YGNode*, YGLogLevel, sbyte*, sbyte*, int> logger);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga6Config3logEPKNS0_4NodeENS0_8LogLevelEPKcPc", ExactSpelling = true)]
        public static extern void log(Config* pThis, [NativeTypeName("const yoga::Node *")] Node* node, [NativeTypeName("facebook::yoga::LogLevel")] LogLevel logLevel, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("va_list")] sbyte* args);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZN8facebook4yoga6Config20setCloneNodeCallbackEPFP6YGNodePKS2_S5_mE", ExactSpelling = true)]
        public static extern void setCloneNodeCallback(Config* pThis, [NativeTypeName("YGCloneNodeFunc")] delegate* unmanaged[Cdecl]<YGNode*, YGNode*, nuint, YGNode*> cloneNode);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.ThisCall, EntryPoint = "__ZNK8facebook4yoga6Config9cloneNodeEPK6YGNodeS4_m", ExactSpelling = true)]
        [return: NativeTypeName("YGNodeRef")]
        public static extern YGNode* cloneNode(Config* pThis, [NativeTypeName("YGNodeConstRef")] YGNode* node, [NativeTypeName("YGNodeConstRef")] YGNode* owner, [NativeTypeName("size_t")] nuint childIndex);

        [DllImport("libyoga.dylib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__ZN8facebook4yoga6Config10getDefaultEv", ExactSpelling = true)]
        [return: NativeTypeName("const Config &")]
        public static extern Config* getDefault();
    }

    public partial struct Config
    {
    }
}
