addNewActivityName = function(name){
    var newEntryId;
    console.log('start -'+name);
    if(dbs.activityNames.find({'name':name}).count() === 0) {
        newEntryId = dbs.activityNames.insert({
            name : name
        });
        return newEntryId;
    } else {
        return dbs.activityNames.findOne({'name':name})['_id'];
    }
};
addNewItem = function(name){
    var newEntryId;

    if(dbs.items.find({'name':name}).count()===0) {
        newEntryId = dbs.items.insert({
            name : name
        });
        return newEntryId;
    } else {
        return dbs.items.findOne({'name':name})['_id'];
    }
};
checkData = function(table, fieldToCheck, fieldValue, wholeObj ){
    var checkObj = {};
    var result;
    checkObj[fieldToCheck] = fieldValue;
    if(dbs[table].find(checkObj).count() === 0) {
        dbs[table].insert(wholeObj, function(){
                result = {type:'added', id:dbs[table].findOne(checkObj)['_id'] }
            }
        );
        var res = function(){
            (function waitforresult(){
                if(result) {
                  return result;
                } else {
                    setTimeout(waitforresult, 60);
                }
            }());
        };
        return res;
    } else {
        return {type:'present', id:dbs[table].findOne(checkObj)['_id']};
    }
};
addNewSkills = function(skillsArray){
    var skillsIds = [];
    var newEntryId;
    skillsArray.forEach(function(elem,i) {
        if(dbs.skills.find({'name':elem}).count() === 0) {
            newEntryId = dbs.skills.insert({
                name : elem
            });
            skillsIds.push(newEntryId);
        } else {
            skillsIds.push(dbs.skills.findOne({'name':elem})['_id']);
        }
    });
    return skillsIds;
}
/*
//fake add
 Meteor.call('addActivity', 'name1', '2014', '01', '2014', '01', 'daily', 'item - book', ['skill-1','skill-2'], 'home', 'color-blue', 'hours-2', function(data){
 console.dir(data);
 })
 */

addActivity = function(ActivityName, yearFromId, monthFromId, yearTillId, monthTillId, activityTypeId, item, skills, place, color, hours){
    var ActivityNameID = addNewActivityName(ActivityName);
    var ItemId = addNewItem(item);
    var skillsIds = addNewSkills(skills);
    var yearFrom  = parseInt(yearFromId, 10);
    var yearTill =  parseInt(yearTillId, 10);
    var monthFrom = parseInt(monthFromId, 10);
    var monthTill = parseInt(monthTillId, 10);
    var lengthData = {};
    var prefillArrayWithNubmers = function(numberFrom, unberTo) {
        var arr = [];
        for (var i = numberFrom; i <= unberTo; i++) {
            arr.push(i);               
        };

        return arr;
    }
     console.log(yearFrom, yearTill);
    if(yearFrom < yearTill) {
       for (var j = yearFrom; j <= yearTill; j++) {
            console.log(j)
            lengthData[j] = {};
            lengthData[j].monthes = [];
            if(j == yearFrom) {
                lengthData[j].monthes = prefillArrayWithNubmers(monthFrom, 12);
                continue;
            }
            if(j == yearTill) {
                lengthData[j].monthes = prefillArrayWithNubmers(1, monthTill);
                continue;                  
            }

            lengthData[j].monthes = prefillArrayWithNubmers(1, 12);
        }; 
    } else {
        lengthData[yearFrom] = {};
        lengthData[yearFrom].monthes = [];
        lengthData[yearFrom].monthes = prefillArrayWithNubmers(monthFrom, monthTill);  
    }


/*    var years = (function(){
        var yearsArr = [];
        for (var i = yearFrom; i <= yearTill; i++) {
            yearsArr.push(i);               
        };

        return yearsArr;
    }());


    var monthes = (function(){
        var monthesArr = [];

        for (var i = monthFrom; i <= monthTill; i++) {
            console.log(i);
            monthesArr.push(i);               
        };

        return monthesArr;
    }());*/

    console.dir('skills-added-'+skillsIds);
    dbs.activities.insert({
		'activityName': '',
        'activityNameId': ActivityNameID,
		'yearFrom': yearFromId ,
		'monthFrom' : monthFromId ,
        'lengthData' : lengthData,
		'yearTill': yearTillId ,
		'monthTill' : monthTillId ,
		'activityType' : activityTypeId,
		'item': ItemId,
		'skills' : skillsIds ,
		'elapsedTime': hours,
		'place' : place,
		'color': color
	});
};

getActivity = function(){
    return dbs.activities.find({}).fetch();
};