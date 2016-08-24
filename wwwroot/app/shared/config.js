"use strict";
exports.Config = {
    pageActions: {
        list: 0,
        edit: 1,
        delete: 2,
        add: 3
    },
    apiUrls: {
        artistsListing: '/api/artists'
    },
    entityFrameworkEntityState: {
        Unchanged: 0,
        Added: 1,
        Modified: 2,
        Deleted: 3
    }
};
