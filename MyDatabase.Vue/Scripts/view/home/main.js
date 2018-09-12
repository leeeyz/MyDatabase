window.onload = function () {
    var vm = new Vue({
        el: "#app",
        data: {
        },
        router: new VueRouter({
            routes: [
                {
                    name: "index",
                    path: "/index",
                    component: index,
                    title: "主页",
                    icon: "el-icon-document",
                },
                {
                    name: "spendType",
                    path: "/spendType",
                    component: spendType,
                    title: "花费类型",
                    icon: "el-icon-document",
                },
                {
                    name: "spend",
                    path: "/spend",
                    component: spend,
                    title: "花费明细",
                    icon: "el-icon-document",
                },
            ]
        }),
    });
};