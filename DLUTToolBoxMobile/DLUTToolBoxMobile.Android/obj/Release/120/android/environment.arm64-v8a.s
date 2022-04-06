	.arch	armv8-a
	.file	"environment.arm64-v8a.arm64-v8a.s"
	.section	.rodata.env.str.1,"aMS",@progbits,1
	.type	.L.env.str.1, @object
.L.env.str.1:
	.asciz	"com.Shirai_Kuroko.DLUTToolBoxMobile"
	.size	.L.env.str.1, 36
	.section	.data.application_config,"aw",@progbits
	.type	application_config, @object
	.p2align	3
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
	.word	3
	/* environment_variable_count */
	.word	12
	/* system_property_count */
	.word	0
	/* number_of_assemblies_in_apk */
	.word	41
	/* bundled_assembly_name_width */
	.word	0
	/* number_of_assembly_store_files */
	.word	2
	/* mono_components_mask */
	.word	0
	/* android_package_name */
	.xword	.L.env.str.1
	.size	application_config, 48
	.section	.rodata.env.str.2,"aMS",@progbits,1
	.type	.L.env.str.2, @object
.L.env.str.2:
	.asciz	"none"
	.size	.L.env.str.2, 5
	.section	.data.mono_aot_mode_name,"aw",@progbits
	.global	mono_aot_mode_name
mono_aot_mode_name:
	.xword	.L.env.str.2
	.section	.rodata.env.str.3,"aMS",@progbits,1
	.type	.L.env.str.3, @object
.L.env.str.3:
	.asciz	"MONO_DEBUG"
	.size	.L.env.str.3, 11
	.section	.rodata.env.str.4,"aMS",@progbits,1
	.type	.L.env.str.4, @object
.L.env.str.4:
	.asciz	"gen-compact-seq-points"
	.size	.L.env.str.4, 23
	.section	.rodata.env.str.5,"aMS",@progbits,1
	.type	.L.env.str.5, @object
.L.env.str.5:
	.asciz	"MONO_GC_PARAMS"
	.size	.L.env.str.5, 15
	.section	.rodata.env.str.6,"aMS",@progbits,1
	.type	.L.env.str.6, @object
.L.env.str.6:
	.asciz	"major=marksweep-conc"
	.size	.L.env.str.6, 21
	.section	.rodata.env.str.7,"aMS",@progbits,1
	.type	.L.env.str.7, @object
.L.env.str.7:
	.asciz	"XAMARIN_BUILD_ID"
	.size	.L.env.str.7, 17
	.section	.rodata.env.str.8,"aMS",@progbits,1
	.type	.L.env.str.8, @object
.L.env.str.8:
	.asciz	"06ec6ad3-443d-406d-b6f9-1d613213fcd0"
	.size	.L.env.str.8, 37
	.section	.rodata.env.str.9,"aMS",@progbits,1
	.type	.L.env.str.9, @object
.L.env.str.9:
	.asciz	"XA_HTTP_CLIENT_HANDLER_TYPE"
	.size	.L.env.str.9, 28
	.section	.rodata.env.str.10,"aMS",@progbits,1
	.type	.L.env.str.10, @object
.L.env.str.10:
	.asciz	"Xamarin.Android.Net.AndroidClientHandler"
	.size	.L.env.str.10, 41
	.section	.rodata.env.str.11,"aMS",@progbits,1
	.type	.L.env.str.11, @object
.L.env.str.11:
	.asciz	"XA_TLS_PROVIDER"
	.size	.L.env.str.11, 16
	.section	.rodata.env.str.12,"aMS",@progbits,1
	.type	.L.env.str.12, @object
.L.env.str.12:
	.asciz	"btls"
	.size	.L.env.str.12, 5
	.section	.rodata.env.str.13,"aMS",@progbits,1
	.type	.L.env.str.13, @object
.L.env.str.13:
	.asciz	"__XA_PACKAGE_NAMING_POLICY__"
	.size	.L.env.str.13, 29
	.section	.rodata.env.str.14,"aMS",@progbits,1
	.type	.L.env.str.14, @object
.L.env.str.14:
	.asciz	"LowercaseCrc64"
	.size	.L.env.str.14, 15
	.section	.data.app_environment_variables,"aw",@progbits
	.type	app_environment_variables, @object
	.p2align	3
	.global	app_environment_variables
app_environment_variables:
	.xword	.L.env.str.3
	.xword	.L.env.str.4
	.xword	.L.env.str.5
	.xword	.L.env.str.6
	.xword	.L.env.str.7
	.xword	.L.env.str.8
	.xword	.L.env.str.9
	.xword	.L.env.str.10
	.xword	.L.env.str.11
	.xword	.L.env.str.12
	.xword	.L.env.str.13
	.xword	.L.env.str.14
	.size	app_environment_variables, 96
	.section	.data.app_system_properties,"aw",@progbits
	.type	app_system_properties, @object
	.p2align	3
	.global	app_system_properties
app_system_properties:
	.size	app_system_properties, 0

	/* Bundled assembly name buffers, all 0 bytes long */
	.section	.bss.bundled_assembly_names,"aw",@nobits

	/* Bundled assemblies data */
	.section	.data.bundled_assemblies,"aw",@progbits
	.type	bundled_assemblies, @object
	.p2align	3
	.global	bundled_assemblies
bundled_assemblies:


	/* Assembly store individual assembly data */
	.section	.data.assembly_store_bundled_assemblies,"aw",@progbits
	.type	assembly_store_bundled_assemblies, @object
	.p2align	3
	.global	assembly_store_bundled_assemblies
assembly_store_bundled_assemblies:
	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	/* image_data */
	.xword	0
	/* debug_info_data */
	.xword	0
	/* config_data */
	.xword	0
	/* descriptor */
	.xword	0

	.size	assembly_store_bundled_assemblies, 1312

	/* Assembly store data */
	.section	.data.assembly_stores,"aw",@progbits
	.type	assembly_stores, @object
	.p2align	3
	.global	assembly_stores
assembly_stores:
	/* data_start */
	.xword	0
	/* assembly_count */
	.word	0
	/* assemblies */
	.zero	4
	.xword	0

	/* data_start */
	.xword	0
	/* assembly_count */
	.word	0
	/* assemblies */
	.zero	4
	.xword	0

	.size	assembly_stores, 48
