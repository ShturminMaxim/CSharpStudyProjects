Meteor.startup(function(){
    dbs = {};
    var tables = [
        'years',
        'monthes',
        'jobs',
        'items',
        'skills',
        'places',
        'achievements',
        'colors',
        'activityTypes',
        'activityNames',
        'users',
        'activities'
    ];
    ;(function(){
       tables.forEach(function(elem,i){
           dbs[elem] = new Meteor.Collection(elem);
       });
    }());

    if(dbs.monthes && dbs.monthes.find({}).count() === 0) {
        var monthes = [
            {number:'01',name:'January'},
            {number:'02',name:'February'},
            {number:'03',name:'March'},
            {number:'04',name:'April'},
            {number:'05',name:'May'},
            {number:'06',name:'June'},
            {number:'07',name:'July'},
            {number:'08',name:'August'},
            {number:'09',name:'September'},
            {number:'10',name:'October'},
            {number:'11',name:'November'},
            {number:'12',name:'December'}
        ];
        monthes.forEach(function(elem,i){
            dbs.monthes.insert(elem);
        });
    }

    if(dbs.years && dbs.years.find({}).count() === 0) {
        var years = [];
        var yearsStart = 1950;
        var yearsEnd = 2017;

        for(var i = yearsStart; i<yearsEnd; i += 1) {
            dbs.years.insert({'number':i});
        }
    }

    Meteor.methods({
        addNewItem:addNewItem,
        addNewActivityName:addNewActivityName,
        checkData:checkData,
        addActivity:addActivity,
        getActivity : getActivity
    });
})