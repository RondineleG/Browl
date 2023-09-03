const withMT = require("@material-tailwind/react/utils/withMT");

module.exports = withMT({
    purge: {
        enabled: true,
        content: [
            './**/*.html',
            './**/*.razor'
        ],
    },
    darkMode: true,
    variants: {
        extend: {},
    },
    plugins: [],
});