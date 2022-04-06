	.arch	armv7-a
	.syntax unified
	.eabi_attribute 67, "2.09"	@ Tag_conformance
	.eabi_attribute 6, 10	@ Tag_CPU_arch
	.eabi_attribute 7, 65	@ Tag_CPU_arch_profile
	.eabi_attribute 8, 1	@ Tag_ARM_ISA_use
	.eabi_attribute 9, 2	@ Tag_THUMB_ISA_use
	.fpu	vfpv3-d16
	.eabi_attribute 34, 1	@ Tag_CPU_unaligned_access
	.eabi_attribute 15, 1	@ Tag_ABI_PCS_RW_data
	.eabi_attribute 16, 1	@ Tag_ABI_PCS_RO_data
	.eabi_attribute 17, 2	@ Tag_ABI_PCS_GOT_use
	.eabi_attribute 20, 2	@ Tag_ABI_FP_denormal
	.eabi_attribute 21, 0	@ Tag_ABI_FP_exceptions
	.eabi_attribute 23, 3	@ Tag_ABI_FP_number_model
	.eabi_attribute 24, 1	@ Tag_ABI_align_needed
	.eabi_attribute 25, 1	@ Tag_ABI_align_preserved
	.eabi_attribute 38, 1	@ Tag_ABI_FP_16bit_format
	.eabi_attribute 18, 4	@ Tag_ABI_PCS_wchar_t
	.eabi_attribute 26, 2	@ Tag_ABI_enum_size
	.eabi_attribute 14, 0	@ Tag_ABI_PCS_R9_use
	.file	"environment.armeabi-v7a.armeabi-v7a.s"
	.section	.rodata.env.str.1,"aMS",%progbits,1
	.type	.L.env.str.1, %object
.L.env.str.1:
	.asciz	"com.Shirai_Kuroko.DLUTToolBoxMobile"
	.size	.L.env.str.1, 36
	.section	.data.application_config,"aw",%progbits
	.type	application_config, %object
	.p2align	2
	.global	application_config
application_config:
	/* uses_mono_llvm */
	.byte	0
	/* uses_mono_aot */
	.byte	0
	/* uses_assembly_preload */
	.byte	1
	/* is_a_bundled_app */
	.byte	0
	/* broken_exception_transitions */
	.byte	0
	/* instant_run_enabled */
	.byte	0
	/* jni_add_native_method_registration_attribute_present */
	.byte	0
	/* have_runtime_config_blob */
	.byte	0
	/* have_assembly_store */
	.byte	1
	/* bound_exception_type */
	.byte	1
	/* package_naming_policy */
	.zero	2
	.long	3
	/* environment_variable_count */
	.long	12
	/* system_property_count */
	.long	0
	/* number_of_assemblies_in_apk */
	.long	41
	/* bundled_assembly_name_width */
	.long	0
	/* number_of_assembly_store_files */
	.long	2
	/* mono_components_mask */
	.long	0
	/* android_package_name */
	.long	.L.env.str.1
	.size	application_config, 44
	.section	.rodata.env.str.2,"aMS",%progbits,1
	.type	.L.env.str.2, %object
.L.env.str.2:
	.asciz	"none"
	.size	.L.env.str.2, 5
	.section	.data.mono_aot_mode_name,"aw",%progbits
	.global	mono_aot_mode_name
mono_aot_mode_name:
	.long	.L.env.str.2
	.section	.rodata.env.str.3,"aMS",%progbits,1
	.type	.L.env.str.3, %object
.L.env.str.3:
	.asciz	"MONO_DEBUG"
	.size	.L.env.str.3, 11
	.section	.rodata.env.str.4,"aMS",%progbits,1
	.type	.L.env.str.4, %object
.L.env.str.4:
	.asciz	"gen-compact-seq-points"
	.size	.L.env.str.4, 23
	.section	.rodata.env.str.5,"aMS",%progbits,1
	.type	.L.env.str.5, %object
.L.env.str.5:
	.asciz	"MONO_GC_PARAMS"
	.size	.L.env.str.5, 15
	.section	.rodata.env.str.6,"aMS",%progbits,1
	.type	.L.env.str.6, %object
.L.env.str.6:
	.asciz	"major=marksweep-conc"
	.size	.L.env.str.6, 21
	.section	.rodata.env.str.7,"aMS",%progbits,1
	.type	.L.env.str.7, %object
.L.env.str.7:
	.asciz	"XAMARIN_BUILD_ID"
	.size	.L.env.str.7, 17
	.section	.rodata.env.str.8,"aMS",%progbits,1
	.type	.L.env.str.8, %object
.L.env.str.8:
	.asciz	"6267789a-5a02-44d1-b899-ff0da59bf65a"
	.size	.L.env.str.8, 37
	.section	.rodata.env.str.9,"aMS",%progbits,1
	.type	.L.env.str.9, %object
.L.env.str.9:
	.asciz	"XA_HTTP_CLIENT_HANDLER_TYPE"
	.size	.L.env.str.9, 28
	.section	.rodata.env.str.10,"aMS",%progbits,1
	.type	.L.env.str.10, %object
.L.env.str.10:
	.asciz	"Xamarin.Android.Net.AndroidClientHandler"
	.size	.L.env.str.10, 41
	.section	.rodata.env.str.11,"aMS",%progbits,1
	.type	.L.env.str.11, %object
.L.env.str.11:
	.asciz	"XA_TLS_PROVIDER"
	.size	.L.env.str.11, 16
	.section	.rodata.env.str.12,"aMS",%progbits,1
	.type	.L.env.str.12, %object
.L.env.str.12:
	.asciz	"btls"
	.size	.L.env.str.12, 5
	.section	.rodata.env.str.13,"aMS",%progbits,1
	.type	.L.env.str.13, %object
.L.env.str.13:
	.asciz	"__XA_PACKAGE_NAMING_POLICY__"
	.size	.L.env.str.13, 29
	.section	.rodata.env.str.14,"aMS",%progbits,1
	.type	.L.env.str.14, %object
.L.env.str.14:
	.asciz	"LowercaseCrc64"
	.size	.L.env.str.14, 15
	.section	.data.app_environment_variables,"aw",%progbits
	.type	app_environment_variables, %object
	.p2align	2
	.global	app_environment_variables
app_environment_variables:
	.long	.L.env.str.3
	.long	.L.env.str.4
	.long	.L.env.str.5
	.long	.L.env.str.6
	.long	.L.env.str.7
	.long	.L.env.str.8
	.long	.L.env.str.9
	.long	.L.env.str.10
	.long	.L.env.str.11
	.long	.L.env.str.12
	.long	.L.env.str.13
	.long	.L.env.str.14
	.size	app_environment_variables, 48
	.section	.data.app_system_properties,"aw",%progbits
	.type	app_system_properties, %object
	.p2align	2
	.global	app_system_properties
app_system_properties:
	.size	app_system_properties, 0

	/* Bundled assembly name buffers, all 0 bytes long */
	.section	.bss.bundled_assembly_names,"aw",%nobits

	/* Bundled assemblies data */
	.section	.data.bundled_assemblies,"aw",%progbits
	.type	bundled_assemblies, %object
	.p2align	2
	.global	bundled_assemblies
bundled_assemblies:


	/* Assembly store individual assembly data */
	.section	.data.assembly_store_bundled_assemblies,"aw",%progbits
	.type	assembly_store_bundled_assemblies, %object
	.p2align	2
	.global	assembly_store_bundled_assemblies
assembly_store_bundled_assemblies:
	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	/* image_data */
	.long	0
	/* debug_info_data */
	.long	0
	/* config_data */
	.long	0
	/* descriptor */
	.long	0

	.size	assembly_store_bundled_assemblies, 656

	/* Assembly store data */
	.section	.data.assembly_stores,"aw",%progbits
	.type	assembly_stores, %object
	.p2align	2
	.global	assembly_stores
assembly_stores:
	/* data_start */
	.long	0
	/* assembly_count */
	.long	0
	/* assemblies */
	.long	0

	/* data_start */
	.long	0
	/* assembly_count */
	.long	0
	/* assemblies */
	.long	0

	.size	assembly_stores, 24
