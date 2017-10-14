// this script is for our pipeline to find type files

const fs = require('fs-extra');

var glob = require("glob");

// options is optional
glob("**/types-gt-mp/", {}, function (er, files) {

	fs.copySync(files[0], 'resources/TerraTex-RL-RPG/types-gt-mp')
});
