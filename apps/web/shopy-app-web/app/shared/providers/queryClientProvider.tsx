'use client';

import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import React from 'react';

const queryClient = new QueryClient({
    defaultOptions: {
        queries: {
            refetchOnWindowFocus: false
        }
    }
});

const QueryProvider = ({ children }: { children: any; }) => {
    return (
        <QueryClientProvider client={queryClient}>
            {children}
        </QueryClientProvider>
    );
};

export default QueryProvider;