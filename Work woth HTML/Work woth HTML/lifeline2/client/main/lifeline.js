/*
activitiesDB;
yearsDB;
monthesDB;
activityNames;
*/

findYearActivity = function(year){
    var arrOfYears = [];
    var currYearActivity = {
        yearNumber:year,
        lineMonth:[]
    };
    monthes.find({}).forEach(function(month){
        var currMonthActivity = {
            monthTitle : month.name,
            customActivities : [],
            dailyActivities: []
        };

        activities.find({'yearFrom': year, 'monthFrom': month.number, 'activityType':'custom'}).forEach(function(activity){
            if(activity && activity.activityNameId) {
                activity.activityName = activityNames.findOne({'_id':activity.activityNameId}).name;
            }
            currMonthActivity.customActivities.push(activity);
        });

        activities.find({'activityType':'daily'}).forEach(function(activity){
            if(activity && activity.activityNameId) {
                activity.activityName = activityNames.findOne({'_id':activity.activityNameId}).name;
            }

            if(activity.lengthData[year] !== undefined && activity.lengthData[year].monthes.indexOf(parseInt(month.number, 10)) >= 0 ) {
            	currMonthActivity.dailyActivities.push(activity);
            }

        });

        
        if(currMonthActivity.customActivities.length || currMonthActivity.dailyActivities.length) {
            currYearActivity.lineMonth.push(currMonthActivity);
        }
    });
    
    arrOfYears.push(currYearActivity);

    return arrOfYears;
};
Template.lifeline.addingNewAct = function(){
	return Session.get('addingNewActivity');
};
Template.lifeline.editindActivity = function(){
    return Session.get('editindActivity');
};

Template.lifeline.events = {
    'click .activity-button' : function(e){
        var elem = jQuery(e.target);
        Session.set('editindActivity', [elem.parent().attr('data-id'), elem.offset().top+(elem.height()/2), elem.offset().left+(elem.width()/2)]);
    }
}
Template.lifeline.lineYear = function () {
	var array = [{
		yearNumber:2014,
		lineMonth:[{
			monthTitle:'January',
			dailyActivities : [{
				activitySize:'small',
				activityColor: 'blue',
				id:'iiiidddd',
				activityName:'Gempan Language courses'
			}],
			customActivities : [{
				activitySize:'small',
				activityColor: 'blue',
				id:'iiiidddd',
				activityName:'Reading NodeJs'
			}]
		},{
			monthTitle:'February',
			dailyActivities : [{
				activitySize:'small',
				activityColor: 'blue',
				id:'iiiidddd',
				activityName:'Gempan Language courses'
			},{
				activitySize:'small',
				activityColor: 'blue',
				id:'iiiidddd',
				activityName:'Maxymiser Academy'
			}],
			customActivities : [{
				activitySize:'small',
				activityColor: 'blue',
				id:'iiiidddd',
				activityName:'Reading NodeJs'
			}]
		},{
			monthTitle:'March',
			dailyActivities : [{
				activitySize:'small',
				activityColor: 'blue',
				id:'iiiidddd',
				activityName:'Gempan Language courses'
			},{
				activitySize:'small',
				activityColor: 'blue',
				id:'iiiidddd',
				activityName:'Maxymiser Academy'
			}],
			customActivities : [{
				activitySize:'small',
				activityColor: 'blue',
				id:'iiiidddd',
				activityName:'Reading NodeJs'
			}]
		},{
			monthTitle:'April',
			dailyActivities : [{
				activitySize:'small',
				activityColor: 'blue',
				id:'iiiidddd',
				activityName:'Gempan Language courses'
			},{
				activitySize:'small',
				activityColor: 'blue',
				id:'iiiidddd',
				activityName:'Maxymiser Academy'
			}],
			customActivities : [{
				activitySize:'small',
				activityColor: 'blue',
				id:'iiiidddd',
				activityName:'Reading NodeJs'
			}]
		}]
	},{
		yearNumber:2015
	}];
	return findYearActivity(2014);
}