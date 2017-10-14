const glob = require("glob");
const path = require('path');
const fs = require('fs');
const validExt = ['.js', '.html', '.css', '.png', '.mp3', '.ogg', '.wav', '.ttf', '.eot', '.svg', '.woff', '.woff2', '.otf'];
let outputString = "";
// options is optional
glob("?*/**/*.*", {matchBase:true}, function (er, files) {
    for(const file of files) {
        if (validExt.indexOf(path.extname(file)) === -1) continue;
        if (file.indexOf("node_modules") !== -1) continue;

        if (path.extname(file) === ".js" && file.indexOf('.min.') === -1 && file.indexOf('-min.') === -1) {
            // check for API
            const content = fs.readFileSync(file);
            if ((content.toString().indexOf("API") !== -1 || !file.startsWith("_IncludedExternalResources")) && !file.startsWith("UI")) {
                outputString += "<script src=\"" + file + "\"  type=\"client\" lang=\"javascript\" /> \n";
            } else {
                outputString += "<file src=\"" + file + "\" /> \n";
            }
        } else {
            outputString += "<file src=\"" + file + "\" /> \n";
        }
    }

    let content = fs.readFileSync("meta.template.xml");
    content = content.toString().replace("<!--PASTE_LINKS_HERE-->", outputString);
    fs.writeFileSync("meta.xml", content);

});