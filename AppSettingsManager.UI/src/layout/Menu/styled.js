import styled from 'styled-components';

export const Container = styled.div`
    height: 100%;
    width: 100%;
`;

export const Head = styled.div`
    height: 60px;
`;

export const Separator = styled.hr`
    border: none;
    height: 1px;
    margin: 0;
    flex-shrink: 0;
    background-color: rgba(0, 0, 0, 0.12);
`;

export const MenuListContainer = styled.div`
    height: calc(100% - 60px - 1px);
`;