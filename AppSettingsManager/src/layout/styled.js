import styled from 'styled-components';

export const Main = styled.div`
    height: 100vh;
    width: 100vw;
    display: flex;
    flex-direction:row;
`;

export const HeaderContainer = styled.div`
    height: 60px;
    background-color: #1976d2;
    display:flex;
    align-items: center;
    padding-left: 10%;
`;

export const ContentContainer = styled.div`
    height: calc(100% - 60px);
`;

export const Title = styled.h2`
    margin: 0;
    color: #008CBA;
`;

export const MenuContainer = styled.div`
    width: 240px;
    border-right: 1px solid rgba(0, 0, 0, 0.12);
`;

export const BodyContainer = styled.div`
    width: calc(100% - 240px - 1px);
`;