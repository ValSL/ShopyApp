'use client';

import { useCheckUser } from "@/app/auth/api/authApi";
import { usePathname, useRouter } from "next/navigation";
import { RoutesPaths, ScopeType, routesConfig } from "@/app/routes";

const PageScopeProvider = ({ children }: { children: any }) => {
    const router = useRouter();
    const route = usePathname();
    const { isSuccess, isError, isLoading } = useCheckUser();

    const { scope } = routesConfig[route as RoutesPaths];


    if(isLoading) return <><p>Loading ...</p></>

    if (scope === ScopeType.PUBLIC && isSuccess) {
        router.push(RoutesPaths.ProductList);
        router.refresh();
        return null;
    }

    if (scope === ScopeType.PRIVATE && isError) {
        router.push(RoutesPaths.Login);
        router.refresh();
        return null;
    }

    return (
        <>
            {children}
        </>
    );
};

export default PageScopeProvider;