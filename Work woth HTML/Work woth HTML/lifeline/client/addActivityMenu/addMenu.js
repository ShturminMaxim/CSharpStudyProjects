/*
* Declared globally Collections in app.js
years = Collection('years');
monthes = Collection('monthes');
*/
Template.addActivityMenu.yearsList = function(){
    return years.find({}).fetch();
}
Template.addActivityMenu.monthesList = function(){
    return monthes.find({}).fetch();
}
Template.addActivityMenu.activityTypeCheck = function(){
	return {
		isDaily:function(){
			if(Session.get('addingNewActivity') === 'daily') {
				return true;
			} else {
				return false;
			}
		},
		isCustom:function(){
			if(Session.get('addingNewActivity') === 'custom') {
				return true;
			} else {
				return false;
			}
		}
	}
};

Template.addActivityMenu.activityType = function() {
	return Session.get('addingNewActivity');
}

Template.addActivityMenu.rendered =function(){
    var d = new Date();
    jQuery('select[name="yearFrom"]').find('option[data-number="'+d.getFullYear()+'"]').attr('selected','selected');
    jQuery('select[name="yearTill"]').find('option[data-number="'+d.getFullYear()+'"]').attr('selected','selected');
};

Template.addActivityMenu.events = {
	'click .overlay, click .close-menu' : function() {
		Session.set('addingNewActivity', false);
	},
    'click .earned-skill .plus button' : function(e){
        e.preventDefault();
        var newSkillInput = jQuery('<input class="input-earned-skill" type="text" name="earned-skill">');
        newSkillInput.insertBefore('.earned-skill .plus');
    },
    'click .ok-btn' : function(){
        var actName = jQuery('#input-what').val(),
            actType = Session.get('addingNewActivity'),
            yf = jQuery('#yearFrom option:selected').data().number,
            yt = jQuery('#yearTill option:selected').data() && jQuery('#yearTill option:selected').data().number || yf,
            mf = jQuery('#monthFrom option:selected').data().number,
            mt = jQuery('#monthTill option:selected').data() && jQuery('#monthTill option:selected').data().number || mf,
            item = jQuery('#input-item').val(),
            skills = [],
            place = jQuery('#input-where').val(),
            color = 'blue',
            hours = jQuery('#hours-spent option:selected').val();

        jQuery('.earned-skill input').each(function(i,elem){
            skills.push(jQuery(elem).val());
        });

        Meteor.call('addActivity', actName, yf, mf, yt, mt, actType, item, skills, place, color, hours, function(data){
            Session.set('addingNewActivity', false);
        });

    }
}