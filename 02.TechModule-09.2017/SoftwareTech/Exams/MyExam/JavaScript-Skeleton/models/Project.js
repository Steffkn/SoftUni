const mongoose = require('mongoose');

let projectSchema = mongoose.Schema({
    //TODO: Implement me ...
});

let Project = mongoose.model('Project', projectSchema);

module.exports = Project;