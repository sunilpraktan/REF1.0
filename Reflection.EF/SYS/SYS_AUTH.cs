using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF
{
    public class SYS_AUTH : ObjectBase
    {
        public int? id { get; set; }
        public bool? selected { get; set; }
        public int? row_no { get; set; }
        public int? seq_no { get; set; }
        public string role_code { get; set; }
        public string role_name { get; set; }
        public string role_alias { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string auth_code { get; set; }
        public string auth_name { get; set; }
        public DateTime? from_date { get; set; }
        public DateTime? to_date { get; set; }
        public string ts_alias { get; set; }
        public string ts_parent { get; set; }
        public string module_code { get; set; }
        public string ind_parent { get; set; }
        public string ind_navigation { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string ts_namespace { get; set; }
        public string ts_nspath { get; set; }
        public string class_file { get; set; }
        public string obj_code { get; set; }
        public string obj_name { get; set; }
        public string obj_class { get; set; }
        public string obj_cat { get; set; }
        public string ts_cat { get; set; }
        public string ts_type { get; set; }
        public string doc_cat { get; set; }
        public string menu_code { get; set; }
        public string menu_name { get; set; }
        public string menu_parent { get; set; }
        public string user_type { get; set; }
        public string user_type_name { get; set; }
        public string title { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string ind_login { get; set; } // Login Status
        public string ind_lock { get; set; } // Lock Status // Depricated. keep only ind_block.
        public string ind_block { get; set; } // Block Status
        public string admin_user { get; set; }
        public DateTime? block_date { get; set; } // for unblock data use seperate tbale to maintain history
        public byte[] user_image { get; set; }
        public string short_text { get; set; }

        public string XML_DOC_A { get; set; }
        public string XML_DOC_B { get; set; }
        public string XML_DOC_C { get; set; }
        public string XML_DOC_D { get; set; }
        public string XML_DOC_E { get; set; }

    }


    public class SYS_C0101 : ObjectBase
    { // user can choose report code for printing because there are multiple choice here. default is full.

        public string comp_code { get; set; }
        public string loc_code { get; set; }
        public string doc_cat { get; set; } // Popup
        public string rpt_code { get; set; } // Popup // Temp not in use because this setting apply to Transaction report.
        public string orientation { get; set; } // Popup // =IIf(Parameters!IsLandscape.Value, "Landscape", "Portrait")

        public double? pm_left { get; set; } // Page Margin
        public double? pm_top { get; set; } // Page Margin
        public double? pm_right { get; set; } // Page Margin
        public double? pm_bottom { get; set; } // Page Margin

        public double? header_height { get; set; }
        public bool header_vis { get; set; } // Checkbox //header_visibility 
        public string hi_display { get; set; } // Popup // Header image display Type: Original Size, Fit to Size, Fit proportional, Clip Image // =IIf(Parameters!ImageSizeMode.Value = "Stretch", "Stretch", "Fit")
        public string header_img { get; set; } // Popup //Header image path
        public string header_img2 { get; set; } // Popup //Header image path

        public double? footer_height { get; set; }
        public bool footer_vis { get; set; } // Checkbox //header_visibility
        public string fi_display { get; set; } // Popup // Footer image display Type: Original Size, Fit to Size, Fit proportional, Clip Image // =IIf(Parameters!ImageSizeMode.Value = "Stretch", "Stretch", "Fit")
        public string footer_img { get; set; } // Popup //Header image path

        public double? sign_height { get; set; } // Degital Signature Height
        public double? sign_width { get; set; } // Degital Signature Width
        public string sign_align { get; set; } // Popup //Digital sign horizontal alignement // =IIf(Parameters!ImageAlignment.Value = "Left", "Left", "Center")
        public string sign_display { get; set; } // Popup // Digital sign image display Type: Original Size, Fit to Size, Fit proportional, Clip Image // =IIf(Parameters!ImageSizeMode.Value = "Stretch", "Stretch", "Fit")
        public string sign_vis { get; set; } // Checkbox // Digital sign image visibility

        public string party_align { get; set; } // Popup //Party Section horizontal alignement // =IIf(Parameters!ImageAlignment.Value = "Left", "Left", "Center")
        public string comp_align { get; set; } // Popup //Company Section horizontal alignement // =IIf(Parameters!ImageAlignment.Value = "Left", "Left", "Center")

        public bool qr_vis { get; set; } //Checkbox
        public bool barcode_vis { get; set; } //Checkbox

        public string ind_default { get; set; } //Checkbox
        public string active { get; set; } //Checkbox

        public string report_code { get; set; }
        public string left_margin { get; set; }
        public string top_margin { get; set; }
        public string right_margin { get; set; }
        public string bottom_margin { get; set; }
        public string header_img_display_view { get; set; }
        public string footer_img_display_view { get; set; }
        public string comp_hori_align_left { get; set; }
        public string comp_hori_align_right { get; set; }
        public string cust_hori_align_left { get; set; }
        public string cust_hori_align_right { get; set; }
        public string digi_sign_width { get; set; }
        public string digi_sign_height { get; set; }
        public bool first_doc_sign_vis { get; set; }
        public bool second_doc_sign_vis { get; set; }
        public bool bottom_logo_vis { get; set; }
        public bool bottom_logo2_vis { get; set; }
        public bool bottom_logo3_vis { get; set; }
        public string first_doc_sign_img { get; set; }
        public string second_doc_sign_img { get; set; }
        public string first_doctor_name { get; set; }
        public string second_doctor_name { get; set; }
        public string first_doctor_desig { get; set; }
        public string second_doctor_desig { get; set; }
        public string first_doctor_reg { get; set; }
        public string second_doctor_reg { get; set; }
        public string bottom_logo_img { get; set; }
        public string bottom_logo2_img { get; set; }
        public string bottom_logo3_img { get; set; }
        public string check_by { get; set; }
        public string nabl_logo_img { get; set; }
        public string header_left_margin { get; set; }
        public decimal header_top_margin { get; set; }
        public decimal header_right_margin { get; set; }
        public decimal header_bottom_margin { get; set; }
        public decimal footer_left_margin { get; set; }
        public decimal footer_top_margin { get; set; }
        public decimal footer_right_margin { get; set; }
        public decimal footer_bottom_margin { get; set; }
    }
    public class Test_Header
    {
        public string patient_name { get; set; }
        public string patient_age { get; set; }
        public string patient_gender { get; set; }
        public string consulting_party { get; set; }
        public string sold_to_party { get; set; }
        public string lab_case_no { get; set; }
        public string grn_date { get; set; }
        public string report_date { get; set; }
        public string qr_img { get; set; }
        public string barcode_img { get; set; }
        public string clinical_note { get; set; }
        public string signature_img_display_size { get; set; }
        public string refered_by_doctor { get; set; }
        public string partner_in { get; set; }
        public string partner_out { get; set; }
        public string shift_to_party { get; set; }
        public string bill_to_party { get; set; }
        public string payer { get; set; }
        public string order_date { get; set; }
        public string lab_code { get; set; }
        public string collection_center { get; set; }
    }
}
