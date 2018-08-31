window.onload = function () {
    var vm = new Vue({
        el: "#app",
        router: new VueRouter({
            routes: [
                { name: "spendType", path: "/spendType", component: spendType },
                { name: "spend", path: "/spend", component: spend },
            ]
        }),
    });
};