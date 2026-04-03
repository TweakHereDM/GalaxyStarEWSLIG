function nextPage(num) {
	var full_name = $('input[name="full_name"]').val();
	//var caste = $('select[name="caste"]').val();
	var caste = 1;
	
	
	var aadhar_number = $('input[name="aadhar_number"]').val();
	var address = $('textarea[name="address"]').val();
	var dob = $('input[name="dob"]').val();
	var mobile_number = $('input[name="mobile_number"]').val();
	var email = $('input[name="email"]').val();
	var account_holder = $('input[name="account_holder"]').val();
	var account_number = $('input[name="account_number"]').val();
	var bank_name = $('select[name="bank_name"]').val();
	var ifsc_code = $('input[name="ifsc_code"]').val();
	var branch_address = $('input[name="branch_address"]').val();

	if (num == 1) {
		$('#pills-personal').addClass('show');
		$('#pills-personal').addClass('active');
		$('#pills-bank').removeClass('show');
		$('#pills-bank').removeClass('active');
		$('#pills-income').removeClass('show');
		$('#pills-income').removeClass('active');

		// FOR ACTIVE TAB PILLS
		$('#pills-personal-details').addClass('active');
		$('#pills-bank-details').removeClass('active');
		$('#pills-income-details').removeClass('active');
	} else if (num == 2) {
		if (full_name == '') {
			$('#full_name').html('Fullname is required !!');
		} else {
			$('#full_name').html('');
		}
		if (dob == '') {
			$('#dob').html('Date of Birth is required !!');
		} else {
			$('#dob').html('');
		}
		if (email == '') {
			$('#email').html('Email is required !!');
		} else {
			$('#email').html('');
		}
		if (mobile_number == '') {
			$('#mobile_number_error').html('Mobile No is required !!');
		} else {
			$('#mobile_number_error').html('');
		}
		if (aadhar_number == '') {
			$('#aadhar_number').html('Aadhar No is required !!');
		} else {
			$('#aadhar_number').html('');
		}
		if (address == '') {
			$('#address').html('Address is required !!');
		} else {
			$('#address').html('');
		}
		if (caste == '') {
			$('#caste').html('Caste is required !!');
		} else {
			$('#caste').html('');
		}
		if (
			(full_name !== '' && dob !== '',
			email !== '' && caste !== '' && mobile_number !== '' && aadhar_number !== '' && address !== '')
		) {
			$('#pills-bank').addClass('show');
			$('#pills-bank').addClass('active');
			$('#pills-personal').removeClass('show');
			$('#pills-personal').removeClass('active');
			$('#pills-income').removeClass('show');
			$('#pills-income').removeClass('active');
			// FOR ACTIVE TAB PILLS
			$('#pills-bank-details').addClass('active');
			$('#pills-personal-details').removeClass('active');
			$('#pills-income-details').removeClass('active');
		}
	} else {
		if (account_holder == '') {
			$('#account_holder').html('Account Holder Name is required !!');
		} else {
			$('#account_holder').html('');
		}
		if (account_number == '') {
			$('#account_number').html('Account No is required !!');
		} else {
			$('#account_number').html('');
		}
		if (bank_name == '') {
			$('#bank_name').html('Bank Name is required !!');
		} else {
			$('#bank_name').html('');
		}
		if (ifsc_code == '') {
			$('#ifsc_code').html('IFSC Code is required !!');
		} else {
			$('#ifsc_code').html('');
		}
		if (branch_address == '') {
			$('#branch_address').html('Branch Address is required !!');
		} else {
			$('#branch_address').html('');
		}
		if (
			(account_holder !== '' && account_number !== '',
			bank_name !== '' && ifsc_code !== '' && branch_address !== '')
		) {
			$('#pills-income').addClass('show');
			$('#pills-income').addClass('active');
			$('#pills-personal').removeClass('show');
			$('#pills-personal').removeClass('active');
			$('#pills-bank').removeClass('show');
			$('#pills-bank').removeClass('active');

			// FOR ACTIVE TAB PILLS
			$('#pills-income-details').addClass('active');
			$('#pills-bank-details').removeClass('active');
			$('#pills-personal-details').removeClass('active');
		}
	}
}

$('#submitCheckBox').click(function() {
	var category = $('select[name="category"]').val();
	var plot_range = $('select[name="plot_range"]').val();
	var policy_name = $('input[name="policy_name"]').val();
	if (category == '') {
		$('#category').html('Category is required !!');
	} else {
		$('#category').html('');
	}
	if (plot_range == '') {
		$('#plot_range').html('Plot Range is required !!');
	} else {
		$('#plot_range').html('');
	}
	if (policy_name == '') {
		$('#policy_name').html('Policy Name is required !!');
	} else {
		$('#policy_name').html('');
	}
	
});

function applicantSubmit() {
	var full_name = $('input[name="full_name"]').val();
	var nameselect = $('input[name="nameselect"]:checked').val();
	var fh_name = $('input[name="fh_name"]').val();
	var idproof = $('input[name="idproof"]:checked').val();
	var id_proof = $('input[name="id_proof"]').val();
	var caste = $('select[name="caste"]').val();
	var aadhar_number = $('input[name="aadhar_number"]').val();
	var city = $('input[name="city"]').val();
	var state = $('input[name="state"]').val();
	var country = $('input[name="country"]').val();
	var zip_code = $('input[name="zip_code"]').val();
	var address = $('textarea[name="address"]').val();
	var dob = $('input[name="dob"]').val();
	var mobile_number = $('input[name="mobile_number"]').val();
	var email = $('input[name="email"]').val();
	var account_holder = $('input[name="account_holder"]').val();
	var account_number = $('input[name="account_number"]').val();
	var bank_name = $('select[name="bank_name"]').val();
	var ifsc_code = $('input[name="ifsc_code"]').val();
	var branch_address = $('input[name="branch_address"]').val();
	var category = $('select[name="category"]').val();
	var plot_range = $('select[name="plot_range"]').val();
	var policy_name = $('input[name="policy_name"]').val();
	var full_name = $('input[name="full_name"]').val();
	var csrf_token = $('input[name="csrf_token"]').val();
	var gender = $('input[name="gender"]').val();
	
	console.log(nameselect)
	console.log(idproof)
	$.ajax({
		url: 'frontController.php',
		method: 'POST',
		data: {
			type: 'register',
			full_name: full_name,
			nameselect: nameselect,
			fh_name: fh_name,
			id_proof: id_proof,
			idproof: idproof,
			caste: caste,
			aadhar_number: aadhar_number,
			city: city,
			state: state,
			country: country,
			zip_code: zip_code,
			address: address,
			dob: dob,
			mobile_number: mobile_number,
			email: email,
			account_holder: account_holder,
			account_number: account_number,
			bank_name: bank_name,
			ifsc_code: ifsc_code,
			branch_address: branch_address,
			category: category,
			plot_range: plot_range,
			policy_name: policy_name,
			csrf_token: csrf_token,
			gender: gender,
			
		},
		success: function(response) {
			if (response == 'register') {
				window.location.href = 'thankyou.php';
			} else {
				alert('Something Went Wrong !!');
			}
		}
	});
}
