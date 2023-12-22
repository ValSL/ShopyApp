export enum ScopeType {
	PUBLIC = "PUBLIC",
	PRIVATE = "PRIVATE",
}

export enum RoutesPaths {
	ProductList = "/home/product-list",
	UserProducts = "/home/user-products",
	Register = "/auth/register",
	Login = "/auth/login",
    Home = "/",
    NotFound = '/_not-found'
}

type RoutesConfig = {
	[route in RoutesPaths]: {
		scope?: ScopeType;
	};
};

export const routesConfig: RoutesConfig = {
    [RoutesPaths.ProductList]: {
        scope: ScopeType.PRIVATE
    },
    [RoutesPaths.UserProducts]: {
        scope: ScopeType.PRIVATE
    },
    [RoutesPaths.Register]: {
        scope: ScopeType.PUBLIC
    },
    [RoutesPaths.Login]: {
        scope: ScopeType.PUBLIC
    },
    [RoutesPaths.Home]: {
        scope: ScopeType.PRIVATE
    },
    [RoutesPaths.NotFound]: {},
}

